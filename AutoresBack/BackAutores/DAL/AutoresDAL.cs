using BackAutores.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackAutores.DAL
{
    public class AutoresDAL
    {
        private readonly string _connectionStrings;

        public AutoresDAL(IConfiguration configuration/*, IDataProtectionProvider protectionProvider*/)
        {
            _connectionStrings = configuration.GetConnectionString("DefaultConnection");

        }


        public async Task<List<AutorResponse>> GetAutores(int id = 0)
        {
            using (SqlConnection sql = new SqlConnection(_connectionStrings))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAuthor", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (id > 0) { cmd.Parameters.Add(new SqlParameter("@pid", id)); }
                    var response = new List<AutorResponse>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue1(reader));
                        }

                    }

                    return response;
                }

            }

        }
        public AutorResponse MapToValue1(SqlDataReader reader)
        {
            return new AutorResponse()
            {
                Id = (int)reader["Id"],
                nombreAutor = reader["nombreAutor"].ToString(),
                fechaNacimiento = reader["fechaNacimiento"].ToString().Split(" ").First(),
                ciudad = reader["ciudad"].ToString(),
                email = reader["email"].ToString(),
                cantidadLibros = (int)reader["cantidadLibros"]

            };
        }


        public async Task<List<LibrosResponse>> GetLibros(int id = 0)
        {
            using (SqlConnection sql = new SqlConnection(_connectionStrings))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetLibros", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (id > 0) { cmd.Parameters.Add(new SqlParameter("@pid", id)); }
                    var response = new List<LibrosResponse>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue2(reader));
                        }

                    }

                    return response;
                }

            }

        }
        public LibrosResponse MapToValue2(SqlDataReader reader)
        {
            return new LibrosResponse()
            {
                Id = (int)reader["Id"],
                titulo = reader["titulo"].ToString(),
                ano = reader["ano"].ToString().Split(" ").First(),
                numeroPaginas = reader["numeroPaginas"].ToString(),
                idAutor = (int)reader["idAutor"],
                nombreAutor = reader["nombreAutor"].ToString(),
            };
        }
    }
}
