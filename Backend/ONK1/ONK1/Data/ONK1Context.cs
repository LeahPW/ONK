using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Models
{
    public class ONK1Context : DbContext
    {
        public ONK1Context (DbContextOptions<ONK1Context> options)
            : base(options)
        {
        }

        public DbSet<Backend.Models.Haandvaerker> Haandvaerker { get; set; }

        public DbSet<Backend.Models.Vaerktoejskasse> Vaerktoejskasse { get; set; }

        public DbSet<Backend.Models.Vaerktoej> Vaerktoej { get; set; }
    }
}
