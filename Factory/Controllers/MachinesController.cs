using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using Factory.Models;

namespace Factory.Controllers
{
    public class MachinesController : Controller
    {

      private readonly FactoryContext _db;

      public MachinesController(FactoryContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Machine> machines = _db.Machines.ToList();
        return View(machines);
      }

      public ActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public ActionResult Create(Machine machine)
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var machine = _db.Machines
            .Include(e => e.Authorizations)
            .ThenInclude(m => m.Engineer)
            .FirstOrDefault(e => e.MachineId == id);
        return View(machine);
      }

      public ActionResult Edit(int id)
      {
        var machine = _db.Machines.FirstOrDefault(e => e.MachineId == id);
        return View(machine);
      }

      [HttpPost]
      public ActionResult Edit(Machine machine)
      {
        _db.Entry(machine).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        var machine = _db.Machines.FirstOrDefault(e => e.MachineId == id);
        return View(machine);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var machine = _db.Machines.FirstOrDefault(e => e.MachineId == id);
        _db.Machines.Remove(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }
}
