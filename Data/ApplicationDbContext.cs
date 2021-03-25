using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSeriesAlexExam.Models;

namespace WebApiSeriesAlexExam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<UsuariosAzure> UsuariosAzure { get; set; }

    }
}
