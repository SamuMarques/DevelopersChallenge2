using DevelopersChallenge.Nibo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ExternalTransaction> ExternalTransaction { get; set; }
        public DbSet<InternalTransaction> InternalTransaction { get; set; }
    }
}
