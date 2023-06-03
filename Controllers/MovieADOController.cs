using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MvcMovie.Models;
using NuGet.Protocol.Plugins;
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
                
                    
                        


                        //list.Add(movieADOs);
                        //list.Add(movieADOs1);

                    
                
                    // command.Connection = connection;


                    /* MovieADO movieADOs = new MovieADO()
                     {
                         Id = int.Parse(reader[0].ToString()),
                         Title = reader[1].ToString(),
                         ReleaseDate = DateTime.Parse(reader[2].ToString()),
                         Genre = reader[3].ToString(),
                         Price = int.Parse(reader[4].ToString()),
                     };

                     */
                    // list.Add(mov);

                    // list.Add(movieADOs);
                    //list.Add(movieADOs1);



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
