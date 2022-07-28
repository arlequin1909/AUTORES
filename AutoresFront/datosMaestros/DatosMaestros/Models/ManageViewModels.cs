using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatosMaestros.Models
{
    public class Autor
    {
        public string nombreAutor { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ciudad { get; set; }
        public string email { get; set; }

    }


    public class Libros
    {
        public string titulo { get; set; }
        public DateTime ano { get; set; }
        public int numeroPaginas { get; set; }
        public int idAutor { get; set; }

    }
}