using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackAutores.Models
{
    public class LibrosDTO
    {
        public int Id { get; set; }

        public string titulo { get; set; }

        public DateTime ano { get; set; }


        public int numeroPaginas { get; set; }


        public int idAutor { get; set; }
    }

    public class LibrosCreacion
    {

        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        public DateTime ano { get; set; }

        [Required(ErrorMessage = "El numeroPaginas es obligatorio")]

        public int numeroPaginas { get; set; }

        [Required(ErrorMessage = "El idAutor es obligatorio")]

        public int idAutor { get; set; }
    }

    public class LibrosResponse
    {
        public int Id { get; set; }

        public string titulo { get; set; }

        public string ano { get; set; }

        public string numeroPaginas { get; set; }

        public int idAutor { get; set; }

        public string nombreAutor { get; set; }

    }

}
