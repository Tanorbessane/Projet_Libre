using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    public class ProjectDataAccessLayer 
    {
        private readonly APIContext db;

        public ProjectDataAccessLayer(APIContext context)
        {
            db = context;
        }


        public List<Project>  FindAll()
        {
            return db.Project.ToList();
        }
        
        public List<Project> GetAllProject(string sort)
        {
            var lst = db.Project.ToList();

            switch (sort)
            {
                case "nom_desc":
                    lst = lst.OrderByDescending(s => s.Nom).ToList();
                    break;
                case "date":
                    lst = lst.OrderBy(s => s.Date).ToList();
                    break;
                case "date_desc":
                    lst = lst.OrderByDescending(s => s.Date).ToList();
                    break;
                default:
                    lst = lst.OrderBy(s => s.Nom).ToList();
                    break;
            }

            return lst;
        }
        
        public Project FindById(int id)
        {
            return db.Project.Find(id);
        }

        public void Insert(Project item)
        {
            db.Project.Add(item);            
            db.SaveChanges();
        }

        public void Update(Project Project)
        {
            db.Project.Update(Project);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            // Project project = db.Project.Find(id);
            //db.Project.Remove(project);
            //db.SaveChanges();
            try
            {
                db.Database.ExecuteSqlCommand("exec [DeleteProject] {0}", id);
            }
            catch
            {
                throw;
            }
        }
    }
}