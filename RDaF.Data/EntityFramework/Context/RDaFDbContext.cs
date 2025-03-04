using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDaF.Shared.Entities.JunctionAggregate;
using RDaF.Shared.Entities.LCStageAggregate;
using RDaF.Shared.Entities.OverarchAggregate;
using RDaF.Shared.Entities.ReferenceAggregate;
using RDaF.Shared.Entities.RoleAggregate;
using RDaF.Shared.Entities.TopicAggregate;
using RDaF.Shared.Infrastructure;

namespace RDaF.Data.EntityFramework.Context
{
    public class RDaFDbContext : DbContext, IUnitOfWork
    {

        public RDaFDbContext(DbContextOptions<RDaFDbContext> options)
          : base(options)
        { }

        public DbSet<LCStage> LCStages { get; private set; }
        public DbSet<Overarch> Overarches { get; private set; }
        public DbSet<Reference> References { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<Topic> Topics { get; private set; }
        public DbSet<Subtopic> Subtopics { get; private set; }
        //Junction tables
        public DbSet<OverarchSubtopic> OverarchSubtopics { get; private set; }
        public DbSet<RoleSubtopic> RoleSubtopics { get; private set; }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(true, cancellationToken);

            return true;
        }


    }
}
