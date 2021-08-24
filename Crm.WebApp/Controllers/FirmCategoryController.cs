using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crm.BusinessLayer;
using Crm.Common;
using Crm.Entities;
using Crm.WebApp.Data;

namespace Crm.WebApp.Controllers
{
    public class FirmCategoryController : Controller
    {
        private FirmCategoryManager firmCategoryManager = new FirmCategoryManager();

        // GET: FirmCategory
        public ActionResult Index()
        {
            return View(firmCategoryManager.List());
        }

        // GET: FirmCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirmCategory firmCategory = firmCategoryManager.Find(x => x.Id == id.Value);
            if (firmCategory == null)
            {
                return HttpNotFound();
            }
            return View(firmCategory);
        }

        // GET: FirmCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirmCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FirmCategory firmCategory)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                firmCategoryManager.Insert(firmCategory);
                return RedirectToAction("Index");
            }

            return View(firmCategory);
        }

        // GET: FirmCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirmCategory firmCategory = firmCategoryManager.Find(x => x.Id == id.Value);
            if (firmCategory == null)
            {
                return HttpNotFound();
            }
            return View(firmCategory);
        }

        // POST: FirmCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FirmCategory firmCategory)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                // TODO : İNCELE
                firmCategoryManager.Update(firmCategory);
                return RedirectToAction("Index");
            }
            return View(firmCategory);
        }

        // GET: FirmCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirmCategory firmCategory = firmCategoryManager.Find(x => x.Id == id.Value);
            if (firmCategory == null)
            {
                return HttpNotFound();
            }
            return View(firmCategory);
        }

        // POST: FirmCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirmCategory firmCategory = firmCategoryManager.Find(x => x.Id == id);
            firmCategoryManager.Delete(firmCategory);
            return RedirectToAction("Index");
        }

    }
}
