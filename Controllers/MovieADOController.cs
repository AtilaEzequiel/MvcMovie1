using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MvcMovie.Models;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MvcMovie.Controllers
{
    public class MovieADOController : Controller
    {

         private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";




        List<MovieADO> list = new List<MovieADO>();

        
        public IActionResult Index()
        {
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string queryString = "SELECT * FROM MovieADO";
            SqlCommand command = new SqlCommand(queryString, connection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MovieADO movieADOs = new MovieADO()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Genre = reader[3].ToString(),
                        Price = int.Parse(reader[4].ToString()),
                    };
                    

                    list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }
                
            }

            connection.Close();

            //      con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            //            con.Open();
            //           string queryString = "SELECT * FROM Usuarios";
            //          SqlConnection connection = new SqlConnection(connectionString);
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieADO mov) 
        {
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (@Id, @titulo, @fecha, @genero, @precio);";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", mov.Id);
                command.Parameters.AddWithValue("@titulo", mov.Title);
                command.Parameters.AddWithValue("@fecha", mov.ReleaseDate);
                command.Parameters.AddWithValue("@genero", mov.Genre);
                command.Parameters.AddWithValue("@precio", mov.Price);




                SqlDataReader reader = command.ExecuteReader();
                

                    connection.Close();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "Select * from MovieADO Where Id=@ID";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MovieADO movieADOs = new MovieADO()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Genre = reader[3].ToString(),
                        Price = int.Parse(reader[4].ToString()),
                    };
                    return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }



                connection.Close();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }

        }


        public IActionResult Edit(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "Select * from MovieADO Where Id=@ID";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MovieADO movieADOs = new MovieADO()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Genre = reader[3].ToString(),
                        Price = int.Parse(reader[4].ToString()),
                    };
                    return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }



                connection.Close();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieADO mov)
        {

            try
            {
                SqlConnection connection = new SqlConnection( connectionString);
                connection.Open();
                string queryString = "update MovieADO   set  titulo=@titulo, fecha=@fecha, genero=@genero, precio=@precio where Id = @Id";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", mov.Id);
                command.Parameters.AddWithValue("@titulo", mov.Title);
                command.Parameters.AddWithValue("@fecha", mov.ReleaseDate);
                command.Parameters.AddWithValue("@genero", mov.Genre);
                command.Parameters.AddWithValue("@precio", mov.Price);




                SqlDataReader reader = command.ExecuteReader();


                connection.Close();

                return RedirectToAction("Index");
                
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }



        public IActionResult Delete(int id) 
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "Select * from MovieADO Where Id=@ID";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MovieADO movieADOs = new MovieADO()
                    {
                        Id = int.Parse(reader[0].ToString()),
                        Title = reader[1].ToString(),
                        ReleaseDate = DateTime.Parse(reader[2].ToString()),
                        Genre = reader[3].ToString(),
                        Price = int.Parse(reader[4].ToString()),
                    };
                    return View(movieADOs);

                    //  list.Add(movieADOs);
                    //list.Add(movieADOs1);
                }



                connection.Close();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(double id, MovieADO mov)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "delete from MovieADO where Id = @Id";
                //string queryString = "INSERT INTO MovieADO (Id, titulo, fecha, genero, precio) VALUES (10, 'Delta', 15/12/1999, 'magia', 600);";
                SqlCommand command = new SqlCommand(queryString, connection);
                //  command.ExecuteReader(queryString);
                command.Parameters.AddWithValue("@Id", mov.Id);
                //command.Parameters.AddWithValue("@titulo", mov.Title);
                //command.Parameters.AddWithValue("@fecha", mov.ReleaseDate);
                //command.Parameters.AddWithValue("@genero", mov.Genre);
                //command.Parameters.AddWithValue("@precio", mov.Price);




                SqlDataReader reader = command.ExecuteReader();


                connection.Close();

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
