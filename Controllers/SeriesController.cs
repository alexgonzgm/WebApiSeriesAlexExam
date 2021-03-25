using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSeriesAlexExam.Models;
using WebApiSeriesAlexExam.Repositories;

namespace WebApiSeriesAlexExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private SeriesRepository repository;
        public SeriesController(SeriesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return this.repository.GetSeries();
        }

        [HttpGet("{id}")]
        public ActionResult<Serie> FindSerie(int id)
        {
            return this.repository.FindSerie(id);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            return this.repository.GetPersonajes();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Personaje> FindPersonaje(int id)
        {
            return this.repository.FindPersonaje(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void AddPersonaje(Personaje personaje)
        {
            this.repository.AddPersonaje(personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
        }

        [HttpPut]
        [Route("[action]/{idpersonaje}/{idserie}")]
        public void UpdatePersonaje(int idpersonaje,int idserie)
        {
            this.repository.CambioSerie(idpersonaje, idserie);
        }

    }
}
