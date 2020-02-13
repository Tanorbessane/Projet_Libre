using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class ReferentielManager
    {
        private  IProjetService _service;
        private  IUserService _serviceUser;
        private  IFileService _serviceFile;
        private IGroupeService _serviceGroups;
        private ITask _serviceTask;

        #region [ Singleton ]

        private static ReferentielManager s_Instance;
        private static readonly object s_InstanceLocker = new object();

        public static ReferentielManager Instance 
        {
            get
             {
                if (s_Instance == null)
                {
                    s_Instance = new ReferentielManager( );
                }
                return s_Instance;
            }
        }

        #endregion [ Singleton ]

        private ReferentielManager()
        {
            _service = new ProjetService();
            _serviceUser = new UserService();
            _serviceFile = new FileService();
            _serviceGroups = new GroupService();
            _serviceTask = new TaskService();
        }
        
        /*Projet*/
        public List<Projet> GetAllProjet()
        {
            List<Projet> lst = _service.Get();

            lst.ForEach(projet =>
            {
                projet.LstFile = GetFilesByProjectId(projet.Id);
                projet.LstUtilisateurs = GetUsersByProjectId(projet.Id);
            });

            if (lst == null)
                lst =  new List<Projet>();
            return lst;
        }

        public Projet GetProjetById(int id)
        {
             return _service.GetById(id);     
        }

        public Projet AddProjet(Projet projet)
        {
            return _service.Add(projet);
        }

        public bool DeleteProjet(int id)
        {
            return _service.DeleteById(id);
        }

        public bool UpdateProjet(Projet projet)
        {
            return _service.Update(projet);
        }

        /*Users*/
        public void InsertUsersByGroupId(int idGroup, string idUser)
        {
           _serviceUser.InsertUsersByGroupId(idGroup,idUser);    
        }

        public void InsertUsersByProjectId(int projectId, string idUser)
        {
            _serviceUser.InsertUsersByProjectId(projectId, idUser);
        }

        public List<Users> GetUsersByProjectId(int id)
        {
            List<Users> users = _serviceUser.GetUsersByProjectId(id);
            return users;
        }

        public List<Users> GetUserByGroupId(int id)
        {
            List<Users> users = _serviceUser.GetUsersByGroupId(id);
            return users;
        }

        public List<Users> GetAllUsers()
        {
            List < Users > lst = _serviceUser.Get();
           if (lst == null)
                lst  = new List<Users>();
            return lst;
        }

        public Users GetUsersById(string id)
        {
            return _serviceUser.GetById(id);
        }

        public bool AddUser(Users Users)
        {
            return _serviceUser.Add(Users);
        }

        public bool DeleteUsers(string id)
        {
            return _serviceUser.DeleteById(id);
        }

        public bool UpdateUsers(Users Users)
        {
            return _serviceUser.Update(Users);
        }

        /*File*/

        public List<File> GetFilesByProjectId(int id)
        {
            List<File> files = _serviceFile.GetFilesByProjectId(id);
            return files;
        }

        public void InsertFilesByProjectId(int projetId, int id)
        {
            _serviceFile.InsertFilesByProjectId(projetId, id);            
        }

        public List<File> GetAllFile()
        {
            List < File > lst =   _serviceFile.Get();
            if (lst == null)
                lst = new List<File>();
            return lst;
        }
               
        public File GetFileById(int id)
        {
            return _serviceFile.GetById(id);
        }

        public File AddFile(File file)
        {
            return _serviceFile.Add(file);
        }

        public bool DeleteFile(int id)
        {
            return _serviceFile.DeleteById(id);
        }

        public bool UpdateFile(File file)
        {
            return _serviceFile.Update(file);
        }

        /*Group*/
        public List<Groups> GetAllGroups()
        {
            try
            {
                return _serviceGroups.Get();
            }
            catch
            {
                return new List<Groups>();
            }
        }

        public Groups GetGroupsById(int id)
        {
            return _serviceGroups.GetById(id);
        }

        public Groups AddGroups(Groups Groups)
        {
            return _serviceGroups.Add(Groups);
        }

        public bool DeleteGroups(int id)
        {
            return _serviceGroups.DeleteById(id);
        }

        public bool UpdateGroups(Groups Groups)
        {
            return _serviceGroups.Update(Groups);
        }

        public  void DeleteUsersByProjectId(int id, string item)
        {
            _serviceUser.DeleteUsersByProjectId(id, item);
        }

        public void DeleteFilesByProjectId(int id, string item)
        {
            _serviceFile.DeleteFilesByProjectId(id, item);
        }


        /*Tâche*/

        public List<Task> GetTaskByProjectId(int id)
        {
            List<Task> Task = _serviceTask.GetTaskByProjectId(id);
            return Task;
        }


        public Task AddTask(Task task)
        {
            return _serviceTask.Add(task);
        }

        public void InsertTaskByProjectId(int projetId, int id)
        {
            _serviceTask. InsertTaskByProjectId(projetId, id);
        }
    }
}
