using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class File
    {
        public bool isInProject;
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public DateTime DateCreation{ get; set; }
  
        public string ImageCaption { set; get; }
        public string ImageDescription { set; get; }
        public Microsoft.AspNetCore.Http.IFormFile MyImage { set; get; }
    }
}
