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
    /// Repository for managing WishList entities.
    /// </summary>
    public sealed class WishListRepository : BaseRepository<WishList>, IWishListRepository
    {

        /// <summary>
        /// Initializes a new instance of the WhishListRepository class.
        /// </summary>
        /// <param name="context">The application context.</param>
        public WishListRepository(IApplicationContext context) : base(context)
        {
        }

    }
}
