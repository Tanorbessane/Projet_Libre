using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Nom{ get; set; }       
        public string Description { get; set; }
        public string Progress { get; set; }
        public DateTime Date{ get; set; }        
    }
}
