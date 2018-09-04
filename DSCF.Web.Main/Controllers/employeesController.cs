using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSCF.Model;
using DSCF.View;
using DSCF.Repository;

namespace DSCF.Web.Main.Controllers
{
    public class employeesController : Controller
    {
        private DSMainContext db = new DSMainContext();
        private EmployeeRepository emp = new EmployeeRepository();

        // GET: employees
        public ActionResult Index()
        {
            return View(emp.getAllEmployee());
        }
        public ActionResult ListEmployee()
        {
            return PartialView("_listEmployee", emp.getAllEmployee());
        }
        public ActionResult SearchEmployee(string keywords)
        {
            return PartialView("_listEmployee", emp.SearchListEmployee(keywords));
        }
        // GET: employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EMPLOYEE eMPLOYEE = db.employees.Find(id);
            EmployeeViewModel employee = emp.getEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMP_ID,NAME,EMAIL,DEPT_ID,ACTIVE")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(eMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEE);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.employees.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.employees.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EMPLOYEE eMPLOYEE = db.employees.Find(id);
            eMPLOYEE.ACTIVE = false;
            //db.employees.Remove(eMPLOYEE);
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
