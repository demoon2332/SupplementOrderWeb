using SupplementOrderWeb.Code;
using SupplementOrderWeb.Models;
using System;

using System.Web;
using System.Web.Mvc;


namespace SupplementOrderWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Customer model) 
        {
            int result = new Customer().Login(model.phone, model.password);

            //Response.Write("<script>alert("+result.ToString()+"")</script>");
            if (result>0 && ModelState.IsValid)
            {
                SessionHelper.setSession(new UserSession() { UserPhone = model.phone });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Wrong phone number or password. Please try again.");
            }
            return View(model);
        }
    }
}