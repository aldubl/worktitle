using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Application.Abstractions.Repositories
{
    /// <summary>
    /// Repository interface for managing Product entities.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
