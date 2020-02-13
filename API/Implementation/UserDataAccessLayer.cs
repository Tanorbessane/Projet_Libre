using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    public class UserDataAccessLayer
    {
        private readonly APIContext _context;

        public UserDataAccessLayer( APIContext context)
        {
            _context = context;
        }

        public List<IdentityUser>  GetAllUser()
        {
            return _context.Users.ToList();
        }
               
        public IdentityUser GetById(string id)
        {
            return _context.Users.First(x => x.Id.Equals(id));
        }

        public void InsertUser(IdentityUser item)
        {
            string newPassword = GenerateRandomPassword(null);
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void UpdateUser(IdentityUser User)
        {
            _context.Users.Update(User);
            _context.SaveChanges();
        }

        public bool InsertUsersByGroupId(string item, int groupId)
        {
            try
            {
                _context.Database.ExecuteSqlCommand("exec [InsertUsersByGroupId] {0}, {1}", groupId, item);
                return true;
            } catch
            {
                return false;
            }
        }

        public List<IdentityUser> GetUsersByProjectId(int id)
        {
            try
            {
               var test =  _context.Users.FromSql("EXECUTE  GetUsersByProjectId {0} ", id).ToList();
                return test;
            }
            catch
            {
                return new List<IdentityUser>();
            }
        }

        public List<IdentityUser> GetUsersByGrouptId(int id)
        {
            try
            {
                var test = _context.Users.FromSql("EXECUTE  [GetUserByGroupId] {0} ", id).ToList();
                return test;
            }
            catch
            {
                return new List<IdentityUser>();
            }
        }

        public void DeleteUser(IdentityUser User)
        {
            try
            {
                _context.Database.ExecuteSqlCommand("exec [DeleteUser] {0}", User.Id);
            }
            catch
            {
            }
        }

        public bool InsertUsersByProjectId(string idUser, int projectId)
        {
            try
            {
                _context.Database.ExecuteSqlCommand("exec [InsertUsersByProjectId] {0}, {1}", projectId, idUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFilesByProjectId(string idUser, int projectId)
        {
            try
            {
                _context.Database.ExecuteSqlCommand("exec [DeleteFilesByProjectId] {0}, {1}", projectId, idUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUsersByProjectId(string idUser, int projectId)
        {
            try
            {
                _context.Database.ExecuteSqlCommand("exec [DeleteUsersByProjectId] {0}, {1}", projectId, idUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region GeneratePassword
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
                    "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                    "abcdefghijkmnopqrstuvwxyz",    // lowercase
                    "0123456789",                   // digits
                    "!@$?_-"                        // non-alphanumeric
    };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

    
        #endregion
    }
}