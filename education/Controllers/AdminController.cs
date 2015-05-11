using education.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace education.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private educationEntities db = new educationEntities();
        //
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.user model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = CheckUser(model.email, model.password);
                if (user != null)
                {
                    //await SignInAsync(user, model.RememberMe);
                    FormsAuthentication.SetAuthCookie(user.email, false);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
                return View("Login", model);
            }

            // If we got this far, something failed, redisplay form
            return View("Login", model);
        }
        public ActionResult LogOff()
        {
            //WebSecurity.Logout();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public user CheckUser(string UserName, string Password)
        {
            var UserLogOn = db.users.SingleOrDefault(m => m.email == UserName && m.password == Password);
            return UserLogOn;
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [Authorize]
        public ActionResult About()
        {
            content content = db.contents.Find(21);
            return View(content);
        }
        [Authorize]
        public ActionResult About_Edit()
        {
            content content = db.contents.Find(21);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: /Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, Authorize, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult About_Edit([Bind(Include = "id,introtext,fulltext")] content content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }
	}
}