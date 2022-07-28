using AutoMapper;
using BackAutores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegronWebApi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //Mapeo desde y hacia 
           
            CreateMap<AutorCreacion,AutorDTO>();

            CreateMap<LibrosCreacion, LibrosDTO>();


        }
    }
}
