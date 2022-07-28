using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackAutores.Models;
using fotoTeca.Autentication;
using AutoMapper;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using BackAutores.DAL;

namespace BackAutores.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AutoresController : ControllerBase
    {
        private readonly AplicationDbContex context;
        private readonly IMapper mapper;
        private readonly AutoresDAL _repository1;

        public AutoresController(AplicationDbContex context, IMapper mapper, AutoresDAL repository1)
        {
            this.context = context;
            this.mapper = mapper;
            _repository1 = repository1 ?? throw new ArgumentNullException(nameof(repository1));

        }

        [HttpPost("/createAuthor", Name = "createAuthor")]
        public async Task<IActionResult> createAuthor(AutorCreacion req)
        {
            try
            {
                var autor = mapper.Map<AutorDTO>(req);
                context.Add(autor);
                await context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch
            {
                return BadRequest($"Se genero un error al crear el autor");
            }
        }


        [HttpPost("/createBook", Name = "createBook")]
        public async Task<IActionResult> createBook(LibrosCreacion req)
        {
            try
            {
                var Libro = mapper.Map<LibrosDTO>(req);
                context.Add(Libro);
                await context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch
            {
                return BadRequest($"Se genero un error al crear el Libro");
            }

        }


        [HttpGet("/getAutores")]
        public async Task<ActionResult<List<AutorResponse>>> Get1()
        {

            try
            {
                return await _repository1.GetAutores();
            }

            catch
            {
                return BadRequest($"Se genero un error al mostrar la informacion");
            }

        }


        [HttpGet("/getAutores/{id}")]
        public async Task<ActionResult<List<AutorResponse>>> Get2(int id)
        {

            try
            {
                return await _repository1.GetAutores(id);
            }

            catch
            {
                return BadRequest($"Se genero un error al mostrar la informacion");
            }

        }

        [HttpGet("/getLibros/{idAutor}")]
        public async Task<ActionResult<List<LibrosResponse>>> Get3(int idAutor)
        {

            try
            {
                return await _repository1.GetLibros(idAutor);
            }

            catch
            {
                return BadRequest($"Se genero un error al mostrar la informacion");
            }

        }


    }
}
