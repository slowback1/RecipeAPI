using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RecipieAPI.Models
{
    public class RouteTree
    {
        public string RT = "This is a tree for all endpoints in this API";
        public Branch PermenantRecipies = new Branch();
        public Branch TemporaryRecipies = new Branch();
        public Branch UserAuth = new Branch();
        public RouteTree()
        {
            
            PermenantRecipies.SetDescription("endpoints for permenant recipies.  All endpoints start with '/recipies/permenant'");
            PermenantRecipies.SetEndpoints(new string[] { 
                "/get : [GET] fetch all recipies", 
                "/get/[integer] : [GET] get recipie of specified id number", 
                "/set : [POST] add new permenant recipie", 
                "/edit/[integer] : [PUT] edit existing recipie", 
                "/delete/[integer] : [DELETE] delete existing recipie"
            });
            TemporaryRecipies.SetDescription("endpoints for temporary recipies. All endpoints start with '/recipies/temporary'");
            TemporaryRecipies.SetEndpoints(new string[] { 
                "/get : [GET] fetch all recipies", 
                "/get/[integer] : [GET] get recipie of specified id number", 
                "/set : [POST] add new permenant recipie", 
                "/edit/[integer] : [PUT] edit existing recipie", 
                "/delete/[integer] : [DELETE] delete existing recipie", 
                "/makepermenant/[integer] : move recipie from temporary to permenant table." 
            });
            UserAuth.SetDescription("endpoints for simple user authentication.  There should only be one active user account (me). Endpoints start with '/user/auth'");
            UserAuth.SetEndpoints(new string[]
            {
                "/verify : [GET] authenticates JWT that should be sent in request header.",
                "/edit: [PUT] edit user login information.  Sends a JWT to be stored.",
                "/login: [POST] authenticates username/password.  Sends a JWT to be stored."
            });

        }
    }
    public class Branch {
        public void SetDescription(string desc)
        {
            Description = desc;
        }
        public void SetEndpoints(string[] endpoints)
        {
            Endpoints = endpoints;
        }
        public string Description;
        public string[] Endpoints;
    }
}
