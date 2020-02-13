using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace API
{
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        ProjectDataAccessLayer objProject;

        public ProjectController(APIContext context)
        {
            objProject = new ProjectDataAccessLayer(context);

            if (context.Project.Count() == 0)
            {
                context.Project.Add(new Project { Nom = "Item1" });
                context.SaveChanges();
            }
        }

        [HttpGet("GetProjects")]
        public IEnumerable<Project> GetProjects()
        {
            PagingParameterModel pagingParameterModel = new PagingParameterModel();
            //Retourne la liste des projets
            List<Project> lsprojects = objProject.FindAll();
            var projets = lsprojects.AsQueryable().OrderBy(x => x.Nom);
            //Obtenir le nombre de lignes
            int count = projets.Count();

            //Le paramétre a passé de la chaine de requete si elle est nulle alors la valeur par défaut de pageNumber sera : 1 
            int CurrentPage = pagingParameterModel.pageNumber;
            //Le paramétre a passé de la chaine de requete si elle est nulle alors la valeur par défaut de pageSize sera : 3 
            int PageSize = pagingParameterModel.pageSize;
            //Afficher la total aux enregistrements
            int TotalCunt = count;
            //Calcul du nombre total de page
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            //Retourne la liste des client aprés l'applicaiton de la pagination
            var item = projets.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            //Si CurrentPage est sup à 1 : cela signifie qu'il a previousPage
            var previousPage = CurrentPage < 1 ? "Oui" : "non";

            //Si TotalPages est sup à CurrentPage : cela signifie qu'il a nectPage
            var nextPage = CurrentPage < TotalPages ? "Oui" : "non";

            //Object que je vais envoyer en Header
            var paginationMetadata = new
            {
                totalCount = TotalPages,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };
            // Definition du Header

            HttpContext.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
            // Nouvelle liste  
            return item.OrderBy(x => x.Id);
        }

        [HttpGet]
        public ActionResult<List<Project>> Index()
        {
            return objProject.FindAll();
        }

        [HttpGet("{sort}", Name = "GetProjectSort")]
        public ActionResult<List<Project>> Index(string sort)
        {
            return objProject.GetAllProject(sort);
        }

        [HttpGet("{id}", Name = "GetProject")]
        public ActionResult<Project> Details(int id)
        {
            var item = objProject.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Project item)
        {
            objProject.Insert(item);
            return CreatedAtRoute("GetProject", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Project item)
        {
            var Project = objProject.FindById(item.Id);
            if (Project == null)
            {
                return NotFound();
            }

            Project.Nom = item.Nom;
            //Project.LstFile = item.LstFile;
            //Project.LstUtilisateurs = item.LstUtilisateurs;

            objProject.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Project = objProject.FindById(id);
            if (Project == null)
            {
                return NotFound();
            }

            objProject.Delete(Project.Id);
            return NoContent();
        }
    }
}
