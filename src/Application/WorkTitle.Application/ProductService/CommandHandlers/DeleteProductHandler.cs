using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.ProductService.Commands;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Application.ProductService.CommandHandlers
{
    public sealed class DeleteProductHandler : IRequestHandler<DeleteProductAsyncCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(DeleteProductAsyncCommand request, CancellationToken cancellationToken)
        {
            var existProduct = await _productRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(Product)} with this id: {request.Id}");

            _productRepository.Delete(existProduct);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
