using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Projet 
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Users> LstUtilisateurs { get; set; }
        public List<File>  LstFile { get; set; }
        public List<Task> task { get; set; }
        public string Progress { get; set; }
    }
}
