using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDaF.Shared.Infrastructure;

namespace RDaF.Data.EntityFramework.Context
{
    public class RDaFDbContext : DbContext, IUnitOfWork
    {

        public RDaFDbContext(DbContextOptions<RDaFDbContext> options)
          : base(options)
        { }





        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(true, cancellationToken);

            return true;
        }


    }
}
