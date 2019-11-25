using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieAPI.Models
{
    public class GetRecipieResponse
    {
        public int ResponseID { get; set; }
        public List<Recipie> ResponseBody { get; set; }

        public GetRecipieResponse(int code, List<Recipie> RB)
        {
            ResponseID = code;
            ResponseBody = RB;
        }
    }
}
