using System.Collections.Generic;

namespace App.Models
{
    internal interface IUserService
    {
        List<Users> Get();
        Users GetById(string id);
        bool Add(Users users);
        bool DeleteById(string id);
        bool Update(Users users);
        void InsertUsersByGroupId(int idGroup, string idUser);
        void InsertUsersByProjectId(int projectId, string idUser);
        List<Users> GetUsersByGroupId(int id);
        List<Users> GetUsersByProjectId(int id);
        void DeleteUsersByProjectId(int id, string item);
    }
}