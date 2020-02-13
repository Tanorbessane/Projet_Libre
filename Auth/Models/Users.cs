using API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{

    public class Users : IdentityUser
    {
        //public string Id{ get; set; }  
        public string role{ get; set; }
        public bool isInProject { get; set; }
        public string Phone { get; set; }
    }

    public class Groups : Group
    {
        public List<Users> Users { get; set; }
        public int NbUsers { get; set; }
    }
}
