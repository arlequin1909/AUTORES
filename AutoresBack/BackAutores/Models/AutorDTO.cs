using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackAutores.Models
{
    public class AutorDTO
    {
        public int Id { get; set; }

        public string nombreAutor { get; set; }

        public DateTime fechaNacimiento { get; set; }


        public string ciudad { get; set; }


        public string email { get; set; }
    }

    public class AutorCreacion
    {
        [Required(ErrorMessage = "El nombreAutor es obligatorio")]

        public string nombreAutor { get; set; }

        [Required(ErrorMessage = "La fechaNacimiento es obligatoria")]

        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]

        public string ciudad { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]


        public string email { get; set; }
    }

    public class AutorResponse
    {
        public int Id { get; set; }

        public string nombreAutor { get; set; }

        public string fechaNacimiento { get; set; }

        public string ciudad { get; set; }

        public string email { get; set; }
        public int cantidadLibros { get; set; }

    }

}
