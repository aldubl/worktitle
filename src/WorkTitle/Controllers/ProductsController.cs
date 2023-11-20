using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WorkTitle.Api.Models;
using WorkTitle.Api.ResponseModels.Product;
using WorkTitle.Application.ProductService.Commands;
using WorkTitle.Application.ProductService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Api.Controllers
{
    /// <summary>
    /// API controller for managing products.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        /// <summary>
        /// Initializes a new instance of the ProductsController class.
        /// </summary>        
        /// <param name="mapper">The mapper.</param>
        /// <param name="sender">The sender for MediatR requests.</param>        
        public ProductsController(IMapper mapper, ISender sender)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Uninitialized property");
            _sender = sender ?? throw new ArgumentNullException(nameof(sender), "Uninitialized property");
        }

        /// <summary>
        /// Retrieves a list of products.
        /// </summary>
        /// <returns>A list of products.</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Получает все товары",
            Description = "Получает все товары из базы данных",
            Tags = new[] { "Product" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получены товары", typeof(List<ProductResponseShort>))]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(_mapper.Map<List<ProductResponseShort>>(await _sender.Send(new GetProductsAsyncQuery())));
        }

        /// <summary>
        /// Retrieves a products by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product with the specified identifier.</returns>
        [HttpGet("{id:Guid}", Name = "GetProductById")]
        [SwaggerOperation(
            Summary = "Получает товар по Id",
            Description = "Получает товар по указанному Id из базы данных",
            Tags = new[] { "Product" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Получен товар с указанным Id", typeof(ProductResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден товар с указанным Id")]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            var product = await _sender.Send(new GetProductByIdAsyncQuery(id));

            return Ok(product);
        }



        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="productModel">The product details to add.</param>
        /// <returns>The newly added product.</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Добавляет товар",
            Description = "Добавляет товар в базу данных и возвращает созданный товар из базы данных",
            Tags = new[] { "Product" }
            )]
        [SwaggerResponse(StatusCodes.Status201Created, "Товар добавлен в базу данных", typeof(ProductResponseShort))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Не указано обязательное поле")]
        public async Task<ActionResult> AddProduct([FromBody] ProductModel productModel)
        {
            var addedProduct = await _sender.Send(new AddProductAsyncCommand(_mapper.Map<ProductDto>(productModel)));

            return CreatedAtRoute("GetProductById", new { id = addedProduct.Id }, _mapper.Map<ProductResponseShort>(addedProduct));
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <param name="productModel">The updated product details.</param>
        /// <returns>The updated product.</returns>
        [HttpPost("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Обновляет товар по Id",
            Description = "Обновляет товар по указанному Id в базе данных и возвращает обновленный товар из базы данных",
            Tags = new[] { "Product" }
            )]
        [SwaggerResponse(StatusCodes.Status202Accepted, "Обновлен товар с указанным Id", typeof(ProductResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден товар с указанным Id для обновления")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Не указано обязательное поле")]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] ProductModel productModel)
        {
            var updatedProduct = await _sender.Send(new UpdateProductAsyncCommand(id, _mapper.Map<ProductDto>(productModel)));

            return AcceptedAtRoute("GetProductById", new { id = updatedProduct.Id }, _mapper.Map<ProductResponseShort>(updatedProduct));
        }

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A message confirming the deletion.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Удаляет товар по Id",
            Description = "Удаляет товар по указанному Id в базе данных",
            Tags = new[] { "Product" }
            )]
        [SwaggerResponse(StatusCodes.Status200OK, "Удален товар с указанным Id", typeof(ProductResponseShort))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Не найден товар с указанным Id для удаления")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _sender.Send(new DeleteProductAsyncCommand(id));

            return Ok($"Product with id = {id} has been removed");
        }
    }
}
