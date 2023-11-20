using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Application.ProductService.Queries;
using WorkTitle.Domain.Entities;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.ProductService.QueriesHandlers
{
    public sealed class GetProductByIdHandler : IRequestHandler<GetProductByIdAsyncQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var existProduct = await _productRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Not found {nameof(Product)} with this id: {request.Id}");

            return _mapper.Map<ProductDto>(existProduct);
        }
    }
}
