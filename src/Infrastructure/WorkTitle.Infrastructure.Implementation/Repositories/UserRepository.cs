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
        /// Initializes a new instance of the UserRepository class.
        /// </summary>
        /// <param name="context">The application context.</param>
        public UserRepository(IApplicationContext context) : base(context)
        {
        }

     }
}
