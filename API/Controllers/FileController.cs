using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        FileDataAccessLayer objFile;

        public FileController(APIContext context)
        {
            objFile = new FileDataAccessLayer(context);

            if (context.Files.Count() == 0)
            {
                context.Files.Add(new File { Nom = "Item1" });
                context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<File>> Index()
        {
            return objFile.GetAllFile();
        }

        [HttpGet("{sort}", Name = "GetFileSort")]
        public ActionResult<List<File>> Index(string sort)
        {
            return   objFile.GetAllFile(sort);
        }
        
        [HttpGet("{id}", Name = "GetFile")]
        public ActionResult<File> Details(int id)
        {
            var item = objFile.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(File item)
        {
            objFile.InsertFile(item);
            return CreatedAtRoute("GetFile", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, File item)
        {
            var File = objFile.GetById(id);
            if (File == null)
            {
                return NotFound();
            }

            File.Nom = item.Nom;
            File.Path = item.Path;

            objFile.UpdateFile(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var File = objFile.GetById(id);
            if (File == null)
            {
                return NotFound();
            }

            objFile.DeleteFile(File);
            return NoContent();
        }

        [HttpGet("GetFilesByProjectId")]
        public ActionResult<List<File>> GetFilesByProjectId(int id)
        {
            List<File> lst = objFile.GetFilesByProjectId(id);
            return lst;
        }

        [HttpPost("InsertFilesByProjectId")]
        public IActionResult CreateFilesByProjectId(int projectId, int idFile)
        {
            bool istrue = objFile.InsertFilesByProjectId(idFile, projectId);
            if (!istrue)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
