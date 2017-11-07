using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using exp1.Models;
using System.Web.Security;
using System.Web.Helpers;

namespace exp1.Controllers
{
    public class HomController : Controller
    {
        private RegContext db1 = new RegContext();
        exp1.Models.RegContext db = new exp1.Models.RegContext();
        Login log = new Login();
        Register reg = new Register();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Login logi)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Login> loglist = db.Logins.ToList().Where(c => c.email_id == logi.email_id).Where(c => c.password == logi.password);
                Login log = loglist.FirstOrDefault();
                if (loglist != null)
                {
                    if (log.email_id == logi.email_id && log.password == logi.password)
                    {
                        HttpContext.Session["Email_Id"] = log.email_id;
                        HttpContext.Session["urole"] = log.urole;
                        return RedirectToAction("Index", "Hom");
                    }
                }
            }
            ModelState.AddModelError("Invalid Login", "Login Data is Incorrect!!!" + logi.email_id + ":" +logi.password);
            return View(logi);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register reg)
        {
            if (ModelState.IsValid)
            {
                Login lg = new Login();
                lg.email_id = reg.email_id;
                lg.password = reg.pwd;
                lg.urole = "user";
                reg.urole = "user";
                db.Registers.Add(reg);
                db.Logins.Add(lg);
                db.SaveChanges();
                return RedirectToAction("Login", "Hom");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Hom");
        }

        
    }
}