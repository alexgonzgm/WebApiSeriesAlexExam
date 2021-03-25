using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSeriesAlexExam.Data;
using WebApiSeriesAlexExam.Models;

namespace WebApiSeriesAlexExam.Repositories
{
    public class SeriesRepository
    {
        private ApplicationDbContext Context;
        public SeriesRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public List<Serie> GetSeries()
        {
            return this.Context.Series.ToList();
        }

        public Serie FindSerie(int id)
        {
            return this.Context.Series.SingleOrDefault(d => d.IdSerie == id);
        }

        public List<Personaje> GetPersonajes()
        {
            return this.Context.Personajes.ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.Context.Personajes.SingleOrDefault(f => f.IdPersonaje == id);
        }

        public void AddPersonaje(string nombre , string imagen , int idserie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetPeronajesMaxId();
            personaje.NombrePersonaje = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.Context.Personajes.Add(personaje);
            this.Context.SaveChanges();


        }

        public int GetPeronajesMaxId()
        {
            return (this.Context.Personajes.Max(c => c.IdPersonaje))+1;
        }

        public void CambioSerie(int idpersonaje , int idserie)
        {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.IdSerie = idserie;
            this.Context.SaveChanges();
        }

       public UsuariosAzure Existe (string nombre , int id)
        {
            return this.Context.UsuariosAzure
                .SingleOrDefault(d => d.Nombre == nombre && d.IdUsuario == id);
        }

        public List<UsuariosAzure> Usuarios()
        {
            return this.Context.UsuariosAzure.ToList();
        }

        public UsuariosAzure findUsuario(int id)
        {
            return this.Context.UsuariosAzure.SingleOrDefault(f => f.IdUsuario == id);
        }
    }
}
