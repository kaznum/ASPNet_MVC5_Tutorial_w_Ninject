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
using AddressBookManagerDomain.Repositories;

namespace MvcMovie.Controllers
{
    public class NormalUsersController : AbstractController
    {
        public NormalUsersController(IAddressBookManagerEntities entities)
        {
            db = entities;
        }

        // GET: /NormalUsers/
        public ActionResult Index()
        {
            var models = new List<NormalUserViewModel>();
            var normalUsers = db.normal_user.ToList();

            var emailAddressRepository = DIFactory.Get<IEmailAddressRepository>();
            normalUsers.ForEach(u =>
            {
                var email = emailAddressRepository.Find(u.logon_id, u.generation);
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

            var normalUserRepository = DIFactory.Get<INormalUserRepository>();
            var emailAddressRepository = DIFactory.Get<IEmailAddressRepository>();

            var normal_user = normalUserRepository.Find((int)id, (int)generation);
            if (normal_user == null)
            {
                return HttpNotFound();
            }
            var email = emailAddressRepository.Find(normal_user.logon_id, (int)generation);

            return View(new NormalUserViewModel(normal_user, email));
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
        public ActionResult Create([Bind(Include="UserID,Generation,FamilyName,GivenName,LogonID,Age,EmailAddress,OccupationCode")] NormalUserViewModel model)
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
            var normalUserRepository = DIFactory.Get<INormalUserRepository>();
            var emailAddressRepository = DIFactory.Get<IEmailAddressRepository>();

            normal_user user = normalUserRepository.Find((int)id, (int)generation);
            if (user == null)
            {
                return HttpNotFound();
            }

            var email = emailAddressRepository.Find(user.logon_id, user.generation);

            return View(new NormalUserViewModel(user, email));
        }

        // POST: /NormalUsers/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Generation,FamilyName,GivenName,LogonId,Age,EmailAddress,OccupationCode")] NormalUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.GetNormalUserEntity();
                var email = model.GetEmailAddressEntity();

                db.Entry(user).State = EntityState.Modified;

                var emailAddressRepository = DIFactory.Get<IEmailAddressRepository>();
                var persistedEmail = emailAddressRepository.Find(user.logon_id, user.generation);
                if (persistedEmail != null) {
                    persistedEmail.address = email.address;
                }
                else
                    db.email_address.Add(email);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /NormalUsers/Delete/5
        public ActionResult Delete(int? id, int? generation)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var normalUserRepository = DIFactory.Get<INormalUserRepository>();
            var emailAddressRepository = DIFactory.Get<IEmailAddressRepository>();

            var normal_user = normalUserRepository.Find((int)id, (int)generation);
            if (normal_user == null)
            {
                return HttpNotFound();
            }
            var email = emailAddressRepository.Find(normal_user.logon_id, normal_user.generation);

            return View(new NormalUserViewModel(normal_user, email));
        }

        // POST: /NormalUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int generation)
        {
            var normalUserRepository = DIFactory.Get<INormalUserRepository>();
            var emailAddressRepository = DIFactory.Get<IEmailAddressRepository>();

            var normal_user = normalUserRepository.Find((int)id, (int)generation);
            var email = emailAddressRepository.Find(normal_user.logon_id, normal_user.generation);
            if (normal_user != null)
                db.normal_user.Remove(normal_user);
            if (email != null)
               db.email_address.Remove(email);
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
