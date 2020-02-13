using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using App.Models;

namespace Auth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
/*
            List<Projet> lstProjet = ReferentielManager.Instance.GetAllProjet();
            List<File> lstFile = ReferentielManager.Instance.GetAllFile();

            if (lstProjet == null)
                lstProjet = new List<Projet>();

            ViewBag.Projet = lstProjet.Count();
            ViewBag.Fichier = (lstFile == null ? 0 : lstFile.Count());

            ViewBag.getListProgressProject = lstProjet;

*/
            ViewBag.Projet = 10;
            ViewBag.Fichier = 10;
            Projet projet = new Projet() { Id = 1, Description = "test", Date = DateTime.Now, Nom = "Net5", Progress = "23%" };
            List<Projet> lst = new List<Projet>();
            lst.Add(projet);
            ViewData["LstProjects"] = lst;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
