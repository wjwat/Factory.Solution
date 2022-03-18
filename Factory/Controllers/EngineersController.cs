using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using Factory.Models;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {

      private readonly FactoryContext _db;

      public EngineersController(FactoryContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        // pass in engineers to display their info in a table
        return View();
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Engineer engineer)
      {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var engineer = _db.Engineers
            .Include(e => e.Authorizations)
            .ThenInclude(m => m.Machine)
            .FirstOrDefault(e => e.EngineerId == id);
        return View(engineer);
      }

      public ActionResult Edit(int id)
      {
        var engineer = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        return View(engineer);
      }

      [HttpPost]
      public ActionResult Edit(Engineer engineer)
      {
        _db.Entry(engineer).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        var engineer = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        return View(engineer);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var engineer = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        _db.Engineers.Remove(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }
}
