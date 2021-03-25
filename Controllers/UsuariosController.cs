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
    public class UsuariosController : ControllerBase
    {
        SeriesRepository repository;
        public UsuariosController(SeriesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<UsuariosAzure>> GetUsuario()
        {
            return this.repository.Usuarios();
        }

        [HttpGet("{id}")]
        public ActionResult<UsuariosAzure> FindUsuario(int id)
        {
            return this.repository.findUsuario(id);
        }
    }
}
