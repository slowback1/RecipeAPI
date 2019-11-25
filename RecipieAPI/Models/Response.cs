using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieAPI.Models
{
    public class Response
    {
        
        public int ResponseID;
        public string ResponseMessage;
        public Response(int RT, string RMess)
        {
            SetId(RT);
            SetMessage(RMess);
        }
        public void SetId(int id)
        {
            ResponseID = id;
        }
        public void SetMessage(string m)
        {
            ResponseMessage = m;
        }
    }
}
