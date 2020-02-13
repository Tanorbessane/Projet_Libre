using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace API
{
    public enum Profil{
        Chef_de_projet = 0,
        Administrateur = 1,
        Gestionnaire_de_cloud = 2,
        Secretaire = 3,
        Etudiant = 4
    }

    public class ApplicationUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Profil role { get; set; }
    }
}
