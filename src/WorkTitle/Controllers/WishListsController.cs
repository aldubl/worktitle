using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.WishList;
using WorkTitle.Application.WishListService.Commands;
using WorkTitle.Application.WishListService.Queries;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Controllers
{
    /// <summary>
    /// API controller for managing wishLists.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WishListsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the WishListsController class.
        /// </summary>        
        /// <param name="mapper">The mapper.</param>
        /// <param name="sender">The sender for MediatR requests.</param>        
        public WishListsController(IMapper mapper, ISender sender)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Uninitialized property");
            _sender = sender ?? throw new ArgumentNullException(nameof(sender), "Uninitialized property");
        }

        /// <summary>
        /// Retrieves a list of wishLists.
        /// </summary>
        /// <returns>A list of wishLists.</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Получает все списки желаний",
            Description = "Получает все списки желаний из базы данных",
            Tags = new[] { "WishList" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получены списки желаний", typeof(List<WishListResponseShort>))]
        public async Task<IActionResult> GetWishLists()
        {
            return Ok(_mapper.Map<List<WishListResponseShort>>(await _sender.Send(new GetWishListsAsyncQuery())));
        }

        /// <summary>
        /// Retrieves a wishList by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the wishList.</param>
        /// <returns>The wishList with the specified identifier.</returns>
        [HttpGet("{id:Guid}", Name = "GetWishListById")]
        [SwaggerOperation(
            Summary = "Получает список желаний по Id",
            Description = "Получает список желаний по указанному Id из базы данных",
            Tags = new[] { "WishList" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получен список с указанным Id", typeof(WishListResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден список желаний с указанным Id")]
        public async Task<ActionResult> GetWishListById(Guid id)
        {
            var wishList = await _sender.Send(new GetWishListByIdAsyncQuery(id));

            return Ok(_mapper.Map<WishListResponse>(wishList));
        }


        /// <summary>
        /// Adds a new wishList.
        /// </summary>
        /// <param name="WishListModel">The wishList details to add.</param>
        /// <returns>The newly added wishList.</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Добавляет список желаний",
            Description = "Добавляет список желаний в базу данных и возвращает созданный список желаний из базы данных",
            Tags = new[] { "WishList" }
            )]
        [SwaggerResponse(StatusCodes.Status201Created, "Список желаний добавлен в базу данных", typeof(WishListResponseShort))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Не указано обязательное поле")]
        public async Task<ActionResult> AddWishList([FromBody] WishListModel wishListModel)
        {
            var addedWishList = await _sender.Send(new AddWishListAsyncCommand(_mapper.Map<WishListDto>(wishListModel)));

            return CreatedAtRoute("GetWishListById", new { id = addedWishList.Id }, _mapper.Map<WishListResponseShort>(addedWishList));
        }

        /// <summary>
        /// Updates an existing wishList.
        /// </summary>
        /// <param name="id">The unique identifier of the wishList to update.</param>
        /// <param name="wishListModel">The updated wishList details.</param>
        /// <returns>The updated wishList.</returns>
        [HttpPost("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Обновляет список желаний по Id",
            Description = "Обновляет список желаний по указанному Id в базе данных и возвращает обновленный список желаний из базы данных",
            Tags = new[] { "WishList" }
            )]
        [SwaggerResponse(StatusCodes.Status202Accepted, "Обновлен список желаний с указанным Id", typeof(WishListResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден список желаний с указанным Id для обновления")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Не указано обязательное поле")]
        public async Task<ActionResult> UpdateWishList(Guid id, [FromBody] WishListModel wishListModel)
        {
            var updatedWishList = await _sender.Send(new UpdateWishListAsyncCommand(id, _mapper.Map<WishListDto>(wishListModel)));

            return AcceptedAtRoute("GetWishListById", new { id = updatedWishList.Id }, _mapper.Map<WishListResponseShort>(updatedWishList));
        }

        /// <summary>
        /// Deletes a wishList by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the wishList to delete.</param>
        /// <returns>A message confirming the deletion.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Удаляет список желаний по Id",
            Description = "Удаляет список желаний по указанному Id в базе данных",
            Tags = new[] { "WishList" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Удален список желаний с указанным Id", typeof(WishListResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден список желаний с указанным Id для удаления")]
        public async Task<IActionResult> DeleteWishList(Guid id)
        {
            await _sender.Send(new DeleteWishListAsyncCommand(id));

            return Ok($"WishList with id = {id} has been removed");
        }
    }
}
