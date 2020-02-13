using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    public class GroupDataAccessLayer 
    {
        #region [Constructeur]
        private readonly APIContext db;

        public GroupDataAccessLayer(APIContext context)
        {
            db = context;
        }

        #endregion

        public List<Group>  FindAll()
        {
            return db.Groups.ToList();
        }
          
        public Group FindById(int id)
        {
            return db.Groups.Find(id);
        }

        public void Insert(Group item)
        {
            db.Groups.Add(item);            
            db.SaveChanges();
        }

        public void Update(Group Group)
        {
            db.Groups.Update(Group);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
           Group Group = db.Groups.Find(id);
            db.Groups.Remove(Group);
            db.SaveChanges();
        }
    }
}