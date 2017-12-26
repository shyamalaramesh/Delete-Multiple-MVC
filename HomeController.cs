using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo6.Models;
namespace MVCDemo6.Controllers
{
    public class HomeController : Controller
    {
        private SampleDBContext1 db = new SampleDBContext1();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            db.Employees.Where(x => employeeIdsToDelete.Contains(x.ID)).ToList().ForEach(y=>db.Employees.Remove(y));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}