using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.Role;
using WorkTitle.Api.ResponseModels.User;
using WorkTitle.Application.RoleService.Commands;
using WorkTitle.Application.RoleService.Queries;
using WorkTitle.Application.UserService.Commands;
using WorkTitle.Application.UserService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Controllers
{
    /// <summary>
    /// API controller for managing users.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the UsersController class.
        /// </summary>        
        /// <param name="mapper">The mapper.</param>
        /// <param name="sender">The sender for MediatR requests.</param>        
        public UsersController(IMapper mapper, ISender sender)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Uninitialized property");
            _sender = sender ?? throw new ArgumentNullException(nameof(sender), "Uninitialized property");
        }

        /// <summary>
        /// Retrieves a list of users.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Получает всеx пользователей",
            Description = "Получает всех пользователей из базы данных",
            Tags = new[] { "User" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получены пользователи", typeof(List<UserResponseShort>))]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_mapper.Map<List<UserResponseShort>>(await _sender.Send(new GetUsersAsyncQuery())));
        }

        /// <summary>
        /// Retrieves a user by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The user with the specified identifier.</returns>
        [HttpGet("{id:Guid}", Name = "GetUserById")]
        [SwaggerOperation(
            Summary = "Получает пользователя по Id",
            Description = "Получает пользователя по указанному Id из базы данных",
            Tags = new[] { "User" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получен пользователь с указанным Id", typeof(UserResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден пользователь с указанным Id")]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            var user = await _sender.Send(new GetUserByIdAsyncQuery(id));

            return Ok(_mapper.Map<UserResponse>(user));
        }

        /// <summary>
        /// Retrieves a user by its chatId.
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns>The user corresponding to its chatId.</returns>
        [HttpGet("chatId/{chatId}", Name = "GetUserByChatId")]
        [SwaggerOperation(
            Summary = "Получает пользователя по ChatId",
            Description = "Получает пользователя по указанному ChatId из базы данных",
            Tags = new[] { "User" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получен пользователь с указанным ChatId", typeof(UserResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден пользователь с указанным ChatId")]
        public async Task<ActionResult> GetUserByChatId(long chatId)
        {
            var user = await _sender.Send(new GetUserByChatIdAsyncQuery(chatId));

            return Ok(_mapper.Map<UserResponse>(user));
        }



        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="userModel">The user details to add.</param>
        /// <returns>The newly added user.</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Добавляет пользователя",
            Description = "Добавляет пользователя в базу данных и возвращает созданного пользователя из базы данных",
            Tags = new[] { "User" }
            )]
        [SwaggerResponse(StatusCodes.Status201Created, "Пользователь добавлен в базу данных", typeof(UserResponseShort))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Не указано обязательное поле")]
        public async Task<ActionResult> AddUser([FromBody]UserModel userModel)
        {
            var userDto = _mapper.Map<UserDto>(userModel);
            //userDto.DefaultListId = new Guid();

            var addedUser = await _sender.Send(new AddUserAsyncCommand(userDto));
            //var addedUser = await _sender.Send(new AddUserAsyncCommand(_mapper.Map<UserDto>(userModel)));

            return CreatedAtRoute("GetUserById", new { id = addedUser.Id }, _mapper.Map<UserResponseShort>(addedUser));
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="userModel">The updated user details.</param>
        /// <returns>The updated user.</returns>
        [HttpPost("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Обновляет пользователя по Id",
            Description = "Обновляет пользователя по указанному Id в базе данных и возвращает обновленного пользователя из базы данных",
            Tags = new[] { "User" }
            )]
        [SwaggerResponse(StatusCodes.Status202Accepted, "Обновлен пользователь с указанным Id", typeof(UserResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден пользователь с указанным Id для обновления")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Не указано обязательное поле")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserModel userModel)
        {
            var updatedUser = await _sender.Send(new UpdateUserAsyncCommand(id, _mapper.Map<UserDto>(userModel)));

            return AcceptedAtRoute("GetUserById", new { id = updatedUser.Id }, _mapper.Map<UserResponseShort>(updatedUser));
        }

        /// <summary>
        /// Deletes a user by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>A message confirming the deletion.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Удаляет пользователя по Id",
            Description = "Удаляет пользователя по указанному Id в базе данных",
            Tags = new[] { "User" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Удален пользователь с указанным Id", typeof(UserResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден пользователь с указанным Id для удаления")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _sender.Send(new DeleteUserAsyncCommand(id));

            return Ok($"User with id = {id} has been removed");
        }
    }
}
