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
    public sealed class AddProductHandler : IRequestHandler<AddProductAsyncCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IWishListRepository _listRepository;
        private readonly IMapper _mapper;

        public AddProductHandler(IProductRepository productRepository, IWishListRepository listRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _listRepository = listRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(AddProductAsyncCommand request, CancellationToken cancellationToken)
        {
            _ = await _listRepository.GetByIdAsync(request.Product.ListId) ??
                throw new KeyNotFoundException($"Not found {nameof(WishList)} with this id: {request.Product.ListId}");

            _productRepository.Add(_mapper.Map<Product>(request.Product));
            await _productRepository.SaveChangesAsync(cancellationToken);

            return request.Product;
        }
    }
}
