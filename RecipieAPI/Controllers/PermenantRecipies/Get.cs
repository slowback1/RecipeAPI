using Microsoft.AspNetCore.Mvc;
using RecipieAPI.Models;
using RecipieAPI.Ref;
using DBConnection;
using System;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;

namespace RecipieAPI.Controllers.PermenantRecipies
{
    [ApiController]
    [Route("/recipies/permenant/get")]
    public class Get
    {
        [HttpGet]
        public string G(int id = -1)
        {
            ResponseCodes rc = new ResponseCodes();
            Connection conn = new Connection();
            StringBuilder sb = new StringBuilder();
            if (id == -1)
            {
                //get all of them
                sb.Append("SELECT * FROM PermenantRecipies;");
            } else
            {
                //get one of them
                sb.Append("SELECT * FROM PermenantRecipies WHERE RecipieID = @RecipieID;");
            }
            string sql = sb.ToString();
            using (SqlCommand query = new SqlCommand(sql))
            {
                query.Connection = conn.connection;
                if(id != -1)
                {
                    query.Parameters.Add("@RecipieID", System.Data.SqlDbType.Int).Value = id;
                }
                try
                {
                    conn.connection.Open();
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        List<Recipie> response = new List<Recipie>();
                        while(reader.Read())
                        {
                            response.Add(new Recipie(
                                    Int32.Parse(reader["RecipieID"].ToString()),
                                    reader["RecipieName"].ToString(),
                                    reader["RecipieDescription"].ToString(),
                                    Int32.Parse(reader["TimesCooked"].ToString()),
                                    reader["RecipieIngredients"].ToString(),
                                    reader["RecipieDirections"].ToString()
                                ));
                        }
                        return JsonConvert.SerializeObject(new GetRecipieResponse(200, response));
                    }
                    

                }
                catch(SqlException)
                {
                    return JsonConvert.SerializeObject(new Response(300, "Error in DB Connection"));
                }
            }
            
        }
    }
}
