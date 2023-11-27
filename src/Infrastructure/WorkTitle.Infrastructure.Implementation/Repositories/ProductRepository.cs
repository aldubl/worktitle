using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Application.Abstractions.Interfaces;
using WorkTitle.Application.Abstractions.Repositories;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Infrastructure.Implementation.Repositories
{
    /// <summary>
    /// Repository for managing Product entities.
    /// </summary>
    public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        /// <summary>
        /// Initializes a new instance of the ProductRepository class.
        /// </summary>
        /// <param name="context">The application context.</param>
        public ProductRepository(IApplicationContext context) : base(context)
        {
        }

    }
}
