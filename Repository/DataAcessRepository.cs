using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class DataAcessRepository
    {

        public List<Person> ReadInfo()
        {
            List<Person> obj = new List<Person>();
            using (SqlConnection conn = new SqlConnection())
            {
                string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                conn.ConnectionString = strcon;
                conn.Open();
                // use the connection here  
                SqlCommand command = new SqlCommand("SELECT * FROM Person", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        obj.Add(new Person()
                        {
                            FirstName = reader[0].ToString(),
                            LastName = reader[1].ToString(),
                            Id = Convert.ToInt32(reader[2])
                        });
                    }
                }
                return obj;
            }
        }
    }
}