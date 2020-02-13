using System.Collections.Generic;

namespace App.Models
{
    public interface IGroupeService
    {
        List<Groups> Get();
        Groups GetById(int id);
        Groups Add(Groups group);
        bool DeleteById(int id);
        bool Update(Groups group);
    }

    public interface ITask
    {
        Task Add(Task task);
        void InsertTaskByProjectId(int projetId, int id);
        List<Task> GetTaskByProjectId(int id);
    }
}