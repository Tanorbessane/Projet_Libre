using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/Group")]
    public class GroupController : Controller
    {
        GroupDataAccessLayer objGroup;

        public GroupController(APIContext context)
        {
            objGroup = new GroupDataAccessLayer(context);

            if (context.Groups.Count() == 0)
            {
                context.Groups.Add(new Group { Nom = "Item1" });
                context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Group>> Index()
        {
            return objGroup.FindAll();
        }

        [HttpGet("{id}", Name = "GetGroup")]
        public ActionResult<Group> Details(int id)
        {
            var item = objGroup.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Group item)
        {
            objGroup.Insert(item);
            return CreatedAtRoute("GetGroup", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Group item)
        {
            var Group = objGroup.FindById(item.Id);
            if (Group == null)
            {
                return NotFound();
            }

            Group.Nom = item.Nom;
            objGroup.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Group = objGroup.FindById(id);
            if (Group == null)
            {
                return NotFound();
            }

            objGroup.Delete(Group.Id);
            return NoContent();
        }
    }
}
