using API;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{

    public class UserService : IUserService
    {
        HttpClient _client = new HttpClient();
        private string uri = "https://localhost:44395/api/user";

        /// <summary>
        /// Récupère l'ensemble des users
        /// </summary>
        /// <returns></returns>
        public List<Users> Get()
        {
            var resp = _client.GetAsync(uri).Result;

            if (resp.IsSuccessStatusCode)
            {
                string lst = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Users>>(lst);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Récupère un user par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Users GetById(string id)
        {
            var resp = _client.GetAsync("https://localhost:44395/api/user/" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Users>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        /// <summary>
        /// Ajouter un user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add(Users user)
        {
           
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            var resp = _client.PostAsync(uri, content).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Supprime un user par id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(string id)
        {
            var resp = _client.DeleteAsync("https://localhost:44395/api/user/" + id).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Modifie un user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(Users user)
        {
            //IdentityUser identityUser = new IdentityUser { UserName = user.Username, Email = user.Email };
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");

            var resp = _client.PutAsync(uri + "/" + user, content).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Recupère tous les utilsateurs d'un projet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Users> GetUsersByProjectId(int id)
        {
            var resp = _client.GetAsync(uri + "/GetUsersByProjectId?id=" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Users>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        /// <summary>
        /// Récupère les utilisateurs par groupe Id
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<Users> GetUsersByGroupId(int id)
        {
            var resp = _client.GetAsync(uri + "/GetUsersByGroupId?id=" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Users>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        /// <summary>
        /// Insert les utilisateurs par group Id
        /// </summary>
        /// <param name="idGroup"></param>
        /// <param name="idUser"></param>
        public void InsertUsersByGroupId(int idGroup, string idUser)
        {
            JObject json = new JObject(new JProperty("idGroup", idGroup), new JProperty("idUser", idUser));
            var httpContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            string url = uri + "/InsertUsersByGroupId?groupId=" + idGroup + "&idUser=" + idUser;
            var resp = _client.PostAsync(url, httpContent).Result;
            if (resp.IsSuccessStatusCode)
            {
                //
            }
        }

        /// <summary>
        /// Insertion des utilisateur par projet Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="idUser"></param>
        public void InsertUsersByProjectId(int projectId, string idUser) {

           JObject json = new JObject(new JProperty("projectId", projectId), new JProperty("idUser", idUser));
           var httpContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            string url = uri + "/InsertUsersByProjectId?projectId="+ projectId + "&idUser="+ idUser;
            var resp = _client.PostAsync(url,httpContent).Result;
            if(resp.IsSuccessStatusCode){
                //
            }
         }

        public void DeleteUsersByProjectId(int id, string item)
        {
            string url = uri + "/DeleteUsersByProjectId?projectID=" + id + "&idUser=" + item;
            var resp = _client.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
            {
                //
            }
        }
    }
}
