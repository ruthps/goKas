using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using goKas.Models;

namespace goKas.Infrastructure
{
    public class KasContext : DbContext
    {
        public KasContext(DbContextOptions<KasContext> options)
            : base(options)
        {

        }
        public DbSet<finance> goKas { get; set; }
    }
}
