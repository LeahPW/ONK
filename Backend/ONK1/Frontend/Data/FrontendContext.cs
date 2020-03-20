using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ONK1.Models;

namespace Frontend.Data
{
    public class FrontendContext : DbContext
    {
        public FrontendContext (DbContextOptions<FrontendContext> options)
            : base(options)
        {
        }

        public DbSet<ONK1.Models.Haandvaerker> Haandvaerker { get; set; }

        public DbSet<ONK1.Models.Vaerktoej> Vaerktoej { get; set; }

        public DbSet<ONK1.Models.Vaerktoejskasse> Vaerktoejskasse { get; set; }
    }
}
