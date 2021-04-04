using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace CW_4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet("{orderBy}")]
        public IActionResult GetAnimals(string orderBy)
        {
            SqlConnection connect = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19240;Integrated Security=True");
            SqlCommand com = new SqlCommand();

            if (orderBy.ToLower().Equals("idanimal"))
            {
                return BadRequest();
            }

            com.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";

            com.Connection = connect;

            connect.Open();

            SqlDataReader dr = com.ExecuteReader();
            List<Animal> animals = new List<Animal>();

            while (dr.Read())
            {
                var an = new Animal
                {
                    IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                };

                animals.Add(an);
            }

            connect.Dispose();
            return Ok(animals);
        }

        [HttpPost]
        public IActionResult CreateAnimals([FromBody] Animal animal)
        {
            SqlConnection connect = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19240;Integrated Security=True");
            SqlCommand com = new SqlCommand
            {
                Connection = connect
            };
            connect.Open();

            com.CommandText = $"INSERT INTO ANIMAL (Name, Description, Category, Area) VALUES ('{animal.Name}', '{animal.Description}', '{animal.Category}', '{animal.Area}')";

            com.ExecuteNonQuery();

            connect.Dispose();
            return GetAnimals("name");
        }

        [HttpDelete("{IdAnimal}")]
        public IActionResult DeleteAnimals(int IdAnimal)
        {
            SqlConnection connect = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19240;Integrated Security=True");
            SqlCommand com = new SqlCommand
            {
                CommandText = "DELETE FROM ANIMAL WHERE IdAnimal = " + IdAnimal + ";",
                Connection = connect
            };
            connect.Open();


            com.ExecuteNonQuery();
            connect.Dispose();
            return GetAnimals("name");
        }
        
        
    }
}