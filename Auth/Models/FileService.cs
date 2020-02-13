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
    public class FileService : IFileService
    {
        HttpClient _client = new HttpClient();
        private string uri = "https://localhost:44395/api/file";

        /// <summary>
        /// Récupère l'ensemble des projets
        /// </summary>
        /// <returns></returns>
        public List<File> Get()
        {
            var resp = _client.GetAsync(uri).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<File>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public File GetById(int id)
        {
            var resp = _client.GetAsync(uri + "/" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<File>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public File Add(File file)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(file), System.Text.Encoding.UTF8, "application/json");
            var resp = _client.PostAsync(uri, content).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<File>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public bool DeleteById(int id)
        {
            var resp = _client.DeleteAsync(uri + "/" + id).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public bool Update(File file)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(file), System.Text.Encoding.UTF8, "application/json");

            var resp = _client.PutAsync(uri + "/" + file.Id, content).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public List<File> GetFilesByProjectId(int id)
        {
            var resp = _client.GetAsync(uri + "/GetFilesByProjectId?id=" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<File>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public void InsertFilesByProjectId(int projectId, int id)
        {
            JObject json = new JObject(new JProperty("projectId", projectId), new JProperty("idFile", id));
            var httpContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            string url = uri + "/InsertFilesByProjectId?projectId=" + projectId + "&idFile=" + id;
            var resp = _client.PostAsync(url, httpContent).Result;
            if (resp.IsSuccessStatusCode)
            {
                //
            }
        }

        public void DeleteFilesByProjectId(int iid, string item)
        {
            string url = uri + "/DeleteFilesByProjectId?projectId=" + iid + "&idUser=" + item;
            var resp = _client.DeleteAsync(url).Result;
            if (resp.IsSuccessStatusCode)
            {
                //
            }
        }
    }
}
