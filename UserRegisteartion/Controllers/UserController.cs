using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegisteartion.Models;

namespace UserRegisteartion.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult ADDorEdit(int id =0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult ADDorEdit( User userModel)
        {
            using(DemoDbModel dbModel = new DemoDbModel())
            {
                if(dbModel.Users.Any( x => x.Username == userModel.Username)){
                    ViewBag.DuplicateMessage = " Username Already exists";
                    return View("AddorEdit", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();


            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registeration Successful";
            return View("ADDorEdit", new User());
        }

    }

}