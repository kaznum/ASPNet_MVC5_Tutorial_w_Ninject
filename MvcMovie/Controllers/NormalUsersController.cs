using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AddressBookManagerDomain.Contexts;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class NormalUsersController : Controller
    {
        private AddressBookManagerEntities db = new AddressBookManagerEntities();

        // GET: /NormalUsers/
        public ActionResult Index()
        {
            var models = new List<NormalUserViewModel>();
            var normalUsers = db.normal_user.ToList();
            normalUsers.ForEach(u =>
            {
                var email = db.email_address.Where(e => e.logon_id == u.logon_id && e.generation == u.generation).FirstOrDefault();
                models.Add(new NormalUserViewModel(u, email));

            });
            return View(models);
        }

        // GET: /NormalUsers/Details/5
        public ActionResult Details(int? id, int? generation)
        {
            if (id == null || generation == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normal_user normal_user = db.normal_user.Where(u => u.user_id == id && u.generation == generation).FirstOrDefault();
            if (normal_user == null)
            {
                return HttpNotFound();
            }
            return View(normal_user);
        }

        // GET: /NormalUsers/Create
        public ActionResult Create()
        {
            var model = new NormalUserViewModel();
            return View(model);
        }

        // POST: /NormalUsers/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserID,Generation,FamilyName,GivenName,LogonID,Age,EmailAddress")] NormalUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.normal_user.Add(model.GetNormalUserEntity());
                db.email_address.Add(model.GetEmailAddressEntity());
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /NormalUsers/Edit/5
        public ActionResult Edit(int? id, int? generation)
        {
            if (id == null || generation == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normal_user normal_user = db.normal_user.Where(u => u.user_id == id && u.generation == generation).FirstOrDefault();
            if (normal_user == null)
            {
                return HttpNotFound();
            }
            return View(normal_user);
        }

        // POST: /NormalUsers/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="user_id,generation,family_name,given_name,logon_id,age")] normal_user normal_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normal_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(normal_user);
        }

        // GET: /NormalUsers/Delete/5
        public ActionResult Delete(int? id, int? generation)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            normal_user normal_user = db.normal_user.Where(u => u.user_id == id && u.generation == generation).FirstOrDefault();
            if (normal_user == null)
            {
                return HttpNotFound();
            }
            return View(normal_user);
        }

        // POST: /NormalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int generation)
        {
            normal_user normal_user = db.normal_user.Where(u => u.user_id == id && u.generation == generation).FirstOrDefault();
            db.normal_user.Remove(normal_user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
