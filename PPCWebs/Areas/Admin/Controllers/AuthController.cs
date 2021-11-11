using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCWebs.Models;

namespace PPCWebs.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth

        AD25Team21Entities model = new AD25Team21Entities();
        public ActionResult Login()
        {
            Session["password-incorrect"] = false;
            Session["user-not-found"] = false;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = model.AdminAccounts.FirstOrDefault(u => u.Email.Equals(email));

            if(user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["user-fullname"] = user.FullName;
                    Session["user-id"] = user.ID;
                    Session["user-role"] = user.Role;
                    return RedirectToAction("Index", "Properties");

                }
                else
                {
                    Session["password-incorrect"] = true;
                    return View();
                }
            }
            Session["user-not-found"] = true;
            return View();
        }

        public ActionResult Logout()
        {
            Session["user-fullname"] = null;
            Session["user-id"] = null;
            return RedirectToAction("Login");
        }
    }
}