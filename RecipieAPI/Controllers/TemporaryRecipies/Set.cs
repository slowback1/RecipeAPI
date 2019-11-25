using DBConnection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipieAPI.Models;
using System.Data.SqlClient;
using System.Text;

namespace RecipieAPI.Controllers.TemporaryRecipies
{
    [ApiController]
    [Route("/recipies/temporary/set")]
    public class Set
    {
        [HttpPost]
        public string P(string i)
        {
            UpRecipie input = JsonConvert.DeserializeObject<UpRecipie>(i);
            if (input.RecipieName == "" || input.RecipieIngredients == "" || input.RecipieDescription == "" || input.RecipieDirections == "" || input.TimesCooked == -1)
            {
                return JsonConvert.SerializeObject(new Response(305, "missing parameters"));
            }

            Connection conn = new Connection();   
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO TemporaryRecipies (RecipieName, RecipieDescription, TimesCooked, RecipieIngredients, RecipieDirections) VALUES (@RecipieName, @RecipieDescription, @TimesCooked, @RecipieIngredients, @RecipieDirections)");


            string sql = sb.ToString();
            using (SqlCommand query = new SqlCommand(sql))
            {
                query.Connection = conn.connection;
                query.Parameters.Add("@RecipieName", System.Data.SqlDbType.Text).Value = input.RecipieName;
                query.Parameters.Add("@RecipieDescription", System.Data.SqlDbType.Text).Value = input.RecipieDescription;
                query.Parameters.Add("@TimesCooked", System.Data.SqlDbType.Int).Value = input.TimesCooked;
                query.Parameters.Add("@RecipieIngredients", System.Data.SqlDbType.Text).Value = input.RecipieIngredients;
                query.Parameters.Add("@RecipieDirections", System.Data.SqlDbType.Text).Value = input.RecipieDirections;
                try
                {
                    conn.connection.Open();
                    query.ExecuteNonQuery();
                    return JsonConvert.SerializeObject(new Response(200, "Ok"));
                }
                catch(SqlException)
                {
                    return JsonConvert.SerializeObject(new Response(300, "Error in DB Connection"));
                }

            }
        }
    }
}