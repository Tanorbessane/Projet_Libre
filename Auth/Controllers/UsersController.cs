using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<Users> lstUsers = ReferentielManager.Instance.GetAllUsers();
            List<Groups> groups = ReferentielManager.Instance.GetAllGroups();        
            foreach(Groups group in groups)
            {
                group.Users = ReferentielManager.Instance.GetUserByGroupId(group.Id);
            }

            ViewBag.Groups = groups;
            return View(lstUsers);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            Users user = ReferentielManager.Instance.GetUsersById(id);
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: Users/Profile
        public ActionResult Profile(string id)
        {
            ViewBag.Projects = ReferentielManager.Instance.GetAllProjet();
            ViewBag.nbFiles = ReferentielManager.Instance.GetAllFile().Count();
            ViewBag.NbProjects = ReferentielManager.Instance.GetAllProjet().Count();
            Users user = ReferentielManager.Instance.GetUsersById(id);
            return View(user);
        }

        // GET: Users/CreateGroup
        public ActionResult CreateGroup()
        {
            ViewBag.lstUsers = ReferentielManager.Instance.GetAllUsers();
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Username,Email,role")] Users user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ReferentielManager.Instance.AddUser(user);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Users/CreateGroup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult CreateGroup([Bind("Nom,Users")] Groups groups, List<string> states)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    API.Models.Group group = new API.Models.Group() { Nom = groups.Nom };
                    Groups groupResult = ReferentielManager.Instance.AddGroups(groups);
                    
                    foreach (var item in states)
                    {
                        ReferentielManager.Instance.InsertUsersByGroupId(groupResult.Id, item);
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            Users user = ReferentielManager.Instance.GetUsersById(id);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit([Bind("Id,Username,Email,role")]Users user)
        {
            try
            {
                ReferentielManager.Instance.UpdateUsers(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            Users user = ReferentielManager.Instance.GetUsersById(id);
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                ReferentielManager.Instance.DeleteUsers(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Users/DeleteGroup/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGroup(int id)
        {
            try
            {
                ReferentielManager.Instance.DeleteGroups(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
 