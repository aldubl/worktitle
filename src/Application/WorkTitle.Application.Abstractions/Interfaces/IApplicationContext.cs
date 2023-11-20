using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WorkTitle.Application.Abstractions.Interfaces
{
    /// <summary>
    /// EntityFramework context interface.
    /// </summary>
    public interface IApplicationContext
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}