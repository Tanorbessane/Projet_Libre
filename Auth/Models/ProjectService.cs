using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace App.Models
{
    public class ProjetService : IProjetService
    {
        public ProjetService()
        {

        }

        HttpClient _client = new HttpClient();
        private string uri = "https://localhost:44395/api/Project";

        /// <summary>
        /// Récupère l'ensemble des projets
        /// </summary>
        /// <returns></returns>
        public List<Projet> Get()
        {
            var resp = _client.GetAsync(uri).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Projet>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }
             
        public Projet GetById(int id)
        {
            var resp = _client.GetAsync(uri + "/" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Projet>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        /// <summary>
        /// Ajouter un projet
        /// </summary>
        /// <param name="Projet"></param>
        /// <returns></returns>
        public Projet Add(Projet Projet)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Projet), System.Text.Encoding.UTF8, "application/json");
            var resp = _client.PostAsync(uri, content).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Projet>(resp.Content.ReadAsStringAsync().Result); 
            else
                return null;
        }

        /// <summary>
        /// Supprime un projet par id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            var resp = _client.DeleteAsync(uri+ "/"+  id).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Modifie un projet
        /// </summary>
        /// <param name="Projet"></param>
        /// <returns></returns>
        public bool Update(Projet Projet)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Projet), System.Text.Encoding.UTF8, "application/json");

            var resp = _client.PutAsync(uri + "/" + Projet.Id, content).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
