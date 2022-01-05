using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAspNetCore.Datos.Modelos.GE
{
    public class GEContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DbSet<Empleado> Empleados { get; set; }

        public GEContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LocalDB"));
        }
    }
}
