using Microsoft.EntityFrameworkCore;
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
    /// Repository for managing Role entities.
    /// </summary>
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {

        /// <summary>
        /// Initializes a new instance of the RoleRepository class.
        /// </summary>
        /// <param name="context">The application context.</param>
        public UserRepository(IApplicationContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves all entities of Role asynchronously.
        /// </summary>
        /// <returns>An enumerable collection of users.</returns>      
        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _entitySet.Include(x => x.Lists).AsNoTracking().ToListAsync();
        }
    }
}
