using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/user")]
    public class UserController : Controller
    {
        UserDataAccessLayer objUser;

        public UserController(  APIContext apicontext)
        {
           objUser = new UserDataAccessLayer( apicontext);
        }

        [HttpGet]
        public ActionResult<List<IdentityUser>> Index()
        {
            return objUser.GetAllUser();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<IdentityUser> Details(string id)
        {
            var item = objUser.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("GetUsersByProjectId")]
        public ActionResult<List<IdentityUser>> GetUsersByProjectId(int id)
        {
           List<IdentityUser> lstUsers = objUser.GetUsersByProjectId(id);
            return lstUsers;
        }

        [HttpGet("GetUsersByGroupId")]
        public ActionResult<List<IdentityUser>> GetUsersByGroupId(int id)
        {
            List<IdentityUser>  lst = objUser.GetUsersByGrouptId(id);
            return lst;
        }

        [HttpPost]
        public IActionResult Create(string username, string email)
        {
            ApplicationUser item = new ApplicationUser() { UserName = username, Email = email };
            objUser.InsertUser(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }

        [HttpPost("InsertUsersByGroupId") ]
        public IActionResult CreateUsersByGroupId(int groupId, string idUser)
        {
            bool istrue =  objUser.InsertUsersByGroupId(idUser, groupId);
            if (!istrue)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("InsertUsersByProjectId")]
        public IActionResult CreateUsersByProjectId(int projectId, string idUser)
        {
            bool istrue = objUser.InsertUsersByProjectId(idUser, projectId);
            if (!istrue)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost ("EditUser")]
        public IActionResult Edit(string id, string username, string email)
        {
            var User = objUser.GetById(id);
            if (User == null)
            {
                return NotFound();
            }

            User.UserName = username;
            User.Email = email;
            //User.PasswordHash = item.PasswordHash;

            objUser.UpdateUser(User);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var User = objUser.GetById(id);
            if (User == null)
            {
                return NotFound();
            }

            objUser.DeleteUser(User);
            return NoContent();
        }

        [HttpDelete("DeleteUsersByProjectId")]
        public IActionResult DeleteUsersByProjectId(int projectId, string idUser)
        {
            bool istrue = objUser.DeleteUsersByProjectId(idUser, projectId);
            if (!istrue)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("DeleteFilesByProjectId")]
        public IActionResult DeleteFilesByProjectId(int projectId, string idUser)
        {
            bool istrue = objUser.DeleteFilesByProjectId(idUser, projectId);
            if (!istrue)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
