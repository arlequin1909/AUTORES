using System;
using System.Web.Mvc;
using System.Data;
using System.Security.Cryptography;
using DatosMaestros.App_Data;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using DatosMaestros.Models;
using System.Threading.Tasks;

namespace DatosMaestros.Controllers
{
    public class HomeController : Controller
    {



        public ActionResult Index(int estadoApi = 0)

        {
            ConnectionDataBase.Apis data = new ConnectionDataBase.Apis();
            DataTable dt = data.ObtenerDataApi("getAutores");
            ViewBag.Autores = dt.Rows;
            Session["estadoApi"] = estadoApi;
            return View();
        }


        public ActionResult CrearAutor()

        {
            return View();
        }

        public ActionResult AgregarLibro(int id)

        {
            ConnectionDataBase.Apis data = new ConnectionDataBase.Apis();
            ViewBag.row = data.ObtenerDataApi("getAutores/" + id).Rows[0];
            var cantidadLibros = ViewBag.row["cantidadLibros"];
            Session["idAutor"] = id;

            if (cantidadLibros == 3)
            {
                DataTable dt = data.ObtenerDataApi("getAutores");
                ViewBag.Autores = dt.Rows;
                Session["estadoApi"] = 7;

                return View("Index");
            }

                return View();

        }


        public ActionResult VerLibrosAutor(int id)

        {
            ConnectionDataBase.Apis data = new ConnectionDataBase.Apis();
            DataTable dt = data.ObtenerDataApi("getLibros/" + id );
            ViewBag.Libros = dt.Rows;
            return View();
        }


        public async Task<ActionResult> SaveLibro(Libros libro)

        {
            ConnectionDataBase.Apis data = new ConnectionDataBase.Apis();

            int res = await data.SaveDataLibro(libro);

            if (res == 4)
            {
                Session["estadoApi"] = res;
            }
            else
            {
                Session["estadoApi"] = res;

            }
            DataTable dt = data.ObtenerDataApi("getAutores");
            ViewBag.Autores = dt.Rows;
            return View("Index");
        }

        public async Task<ActionResult> SaveAutor(Autor autor)

        {
            ConnectionDataBase.Apis data = new ConnectionDataBase.Apis();

            int res = await data.SaveDataAutor(autor);


            if (res == 1)
            {
                Session["estadoApi"] = res;
            }
            else
            {
                Session["estadoApi"] = res;

            }

            DataTable dt= data.ObtenerDataApi("getAutores");
            ViewBag.Autores = dt.Rows;
            return View("Index");
        }
    }
}