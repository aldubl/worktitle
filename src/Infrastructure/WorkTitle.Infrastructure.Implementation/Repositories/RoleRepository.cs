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
    public sealed class RoleRepository : BaseRepository<Role>, IRoleRepository
    {

        /// <summary>
        /// Initializes a new instance of the RoleRepository class.
        /// </summary>
        /// <param name="context">The application context.</param>
        public RoleRepository(IApplicationContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves all entities of Role asynchronously.
        /// </summary>
        /// <returns>An enumerable collection of roles.</returns>      
        public override async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _entitySet.Include(x => x.Users).AsNoTracking().ToListAsync();
        }
    }
}
