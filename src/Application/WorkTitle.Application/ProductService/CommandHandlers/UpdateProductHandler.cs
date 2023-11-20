using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.ProductService.Commands;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.ProductService.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductAsyncCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductAsyncCommand request, CancellationToken cancellationToken)
        {
            var existProduct = await _productRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(Product)} with this id: {request.Id}");

            _mapper.Map(request.Product, existProduct).Id = request.Id;

            _productRepository.Update(_mapper.Map<Product>(existProduct));
            await _productRepository.SaveChangesAsync(cancellationToken);

            return request.Product;
        }
    }
}
