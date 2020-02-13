using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.Models
{
    public class GroupService : IGroupeService
    {
        HttpClient _client = new HttpClient();
        private string uri = "https://localhost:44395/api/Group";

        public Groups Add(Groups group)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(group), System.Text.Encoding.UTF8, "application/json");
            var resp = _client.PostAsync(uri, content).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Groups>(resp.Content.ReadAsStringAsync().Result); 
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

        public List<Groups> Get()
        {
            var resp = _client.GetAsync(uri).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<Groups>>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;

            //new List<Groups>();
            //var lstgroups = _context.Groups.ToList();
            //lstgroups.ForEach(x =>
            //{
            //    var users = _context.Users.FromSql("EXECUTE  GetUserByGroupId {0} ", x.Id).ToList();
            //    groups.Add(new Groups() { Id = x.Id, Nom = x.Nom, NbUsers = users.Count() });
            //});
        }

        public Groups GetById(int id)
        {
            var resp = _client.GetAsync(uri + id).Result;

            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Groups>(resp.Content.ReadAsStringAsync().Result);
            else
                return null;
        }

        public bool Update(Groups group)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(group), System.Text.Encoding.UTF8, "application/json");

            var resp = _client.PutAsync(uri + "/" + group.Id, content).Result;

            if (resp.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
