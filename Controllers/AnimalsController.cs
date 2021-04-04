using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CW_4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        List<Animal> animals = new List<Animal>();



        public AnimalsController()
        {

            [HttpGet]
            IActionResult GetAnimals(string orderBy)
            {
                SqlConnection connect = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19240;Integrated Security=True");
                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT * FROM Animal";
                com.CommandText = " ORDER BY Name ASC WHERE NAME = " + orderBy + " Name";

                com.Connection = connect;

                connect.Open();

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {

                    var an = new Animal();

                    an.Name = dr["Name"].ToString();
                    an.Discription = dr["Discription"].ToString();
                    an.Category = dr["Category"].ToString();
                    an.Area = dr["Area"].ToString();



                    animals.Add(an);

                }


                return Ok(animals);
                connect.Dispose();

            }

            [HttpPost]
            IActionResult CreateAnimals(Animal animal)

            {
                SqlConnection connect = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19240;Integrated Security=True");
                SqlCommand com = new SqlCommand();
                com.CommandText = "SELECT MAX(idAnimal) FROM Animal";
                int maxId = Convert.ToInt16(com.ExecuteScalar().ToString()) + 1;

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {

                    var ani = new Animal();

                    ani.IdAnimal = Int32.Parse(dr["IdAnimal"].ToString());
                    ani.Name = dr["Name"].ToString();
                    ani.Discription = dr["Discription"].ToString();
                    ani.Category = dr["Category"].ToString();
                    ani.Area = dr["Area"].ToString();



                    animals.Add(ani);






                    com.CommandText = "INSERT INTO ANIMAL ( idAnimal ,  Name , description , category , area) VALUES (  anim.idAnimal , anim.Name , anim.descript ,anim.category ,anim.area)";


                }

                return Ok(animals);
                connect.Dispose();


            }

            [HttpDelete("{IdAnimal}")]
            IActionResult DeleteAnimals(int IdAnimal)
            {

                SqlConnection connect = new SqlConnection("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s19240;Integrated Security=True");
                SqlCommand com = new SqlCommand();


                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {

                    var anim = new Animal();

                    anim.IdAnimal = Int32.Parse(dr["IdAnimal"].ToString());
                    anim.Name = dr["Name"].ToString();
                    anim.Discription = dr["Discription"].ToString();
                    anim.Category = dr["Category"].ToString();
                    anim.Area = dr["Area"].ToString();



                    animals.Add(anim);

                    com.CommandText = "DELETE FROM ANIMAL WHERE IdAnimal = " + IdAnimal + "";



                }

                return Ok(animals);
                connect.Dispose();



                [HttpPut("{idAnima}")]
                IActionResult UpdateAnimals(int id)
                {
                    return Ok("");
                }

            }
        }
    }
}






                
       


 




    