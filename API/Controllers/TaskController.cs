using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        TaskDataAccessLayer objTask;

        public TaskController(APIContext context)
        {
            objTask = new TaskDataAccessLayer(context);

            if (context.Tasks.Count() == 0)
            {
                context.Tasks.Add(new Task { Tache = "Item1" , Description =""});
                context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Task>> Index()
        {
            return objTask.GetAllTask();
        }

        [HttpGet("{id}", Name = "GetTask")]
        public ActionResult<Task> Details(int id)
        {
            var item = objTask.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Task item)
        {
            objTask.InsertTask(item);
            return CreatedAtRoute("GetTask", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Task item)
        {
            var Task = objTask.GetById(id);
            if (Task == null)
            {
                return NotFound();
            }
            
            objTask.UpdateTask(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Task = objTask.GetById(id);
            if (Task == null)
            {
                return NotFound();
            }

            objTask.DeleteTask(Task);
            return NoContent();
        }

        [HttpGet("GetTasksByProjectId")]
        public ActionResult<List<Task>> GetTasksByProjectId(int id)
        {
            List<Task> lst = objTask.GetTasksByProjectId(id);
            return lst;
        }

        [HttpPost("InsertTasksByProjectId")]
        public IActionResult CreateTasksByProjectId(int projectId, int idTask)
        {
            bool istrue = objTask.InsertTasksByProjectId(idTask, projectId);
            if (!istrue)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
