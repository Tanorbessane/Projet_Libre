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
    public class TaskService : ITask
    {
        HttpClient _client = new HttpClient();
        private string uri = "https://localhost:44395/api/task";


        public Task Add(Task Task)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(Task), System.Text.Encoding.UTF8, "application/json");
            var resp = _client.PostAsync(uri, content).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Task>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public void InsertTaskByProjectId(int projectId, int id)
        {
            JObject json = new JObject(new JProperty("projectId", projectId), new JProperty("idTask", id));
            var httpContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            string url = uri + "/InsertTasksByProjectId?projectId=" + projectId + "&idTask=" + id;
            var resp = _client.PostAsync(url, httpContent).Result;
            if (resp.IsSuccessStatusCode)
            {
                //
            }
        }

        public List<Task> GetTaskByProjectId(int id)
        {
            var resp = _client.GetAsync(uri + "/GetTasksByProjectId?id=" + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Task>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

    }
}
