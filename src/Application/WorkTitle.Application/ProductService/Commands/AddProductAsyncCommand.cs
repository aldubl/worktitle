﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.EntitiesDto;

namespace WorkTitle.Application.ProductService.Commands
{
    public sealed record AddProductAsyncCommand(ProductDto Product) : IRequest<ProductDto>;
}
