using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1.Data
{
    public class dbfirst : DbContext
    {
        public dbfirst(DbContextOptions<dbfirst> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.model.Employee> Employee { get; set; } = default!;
    }
}
