using BackAutores.Models;
using fotoTeca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fotoTeca.Autentication
{
    public class AplicationDbContex : IdentityDbContext<AplicationUser>
    {
        public AplicationDbContex(DbContextOptions<AplicationDbContex> options)
           : base(options)
        {

        }

        public DbSet<AutorDTO> TB_Autores { get; set; }

        public DbSet<LibrosDTO> TB_Libros { get; set; }

    }
}
