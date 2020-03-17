using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ONK1.Models;

namespace ONK1.Models
{
    public class ONK1Context : DbContext
    {
        public ONK1Context (DbContextOptions<ONK1Context> options)
            : base(options)
        {
        }

        public DbSet<ONK1.Models.Haandvaerker> Haandvaerker { get; set; }

        public DbSet<ONK1.Models.Vaerktoejskasse> Vaerktoejskasse { get; set; }

        public DbSet<ONK1.Models.Vaerktoej> Vaerktoej { get; set; }
    }
}
