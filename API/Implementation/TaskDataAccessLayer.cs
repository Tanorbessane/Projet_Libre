using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    public class TaskDataAccessLayer 
    {
        private readonly APIContext db;

        public TaskDataAccessLayer(APIContext context)
        {
            db = context;
        }

        public List<Task>  GetAllTask()
        {
            return db.Tasks.ToList();
        }
        
        public Task GetById(int id)
        {
            return db.Tasks.Find(id);
        }

        public Task InsertTask(Task item)
        {
            db.Tasks.Add(item);
            db.SaveChanges();
            return item;
        }

        public void UpdateTask(Task Task)
        {
            db.Tasks.Update(Task);
            db.SaveChanges();
        }

        public void DeleteTask(Task Task)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec [DeleteTask] {0}", Task.Id);
            }
            catch
            {
            }
        }

        public List<Task> GetTasksByProjectId(int id)
        {
            try
            {
                var test = db.Tasks.FromSql("EXECUTE  GetTasksByProjectId {0} ", id).ToList();
                return test;
            }
            catch
            {
                return new List<Task>();
            }
        }

        public bool InsertTasksByProjectId(int item, int projectId)
        {
            try
            {
                db.Database.ExecuteSqlCommand("exec [InsertTasksByProjectId] {0}, {1}", projectId, item);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}