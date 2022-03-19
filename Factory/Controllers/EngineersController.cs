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
        List<Engineer> engineers = _db.Engineers.ToList();
        return View(engineers);
      }

      public ActionResult Create()
      {
        ViewBag.Machines = _db.Machines.ToList();
        return View();
      }

      [HttpPost]
      public ActionResult Create(Engineer engineer, int[] MachineId)
      {
        System.Console.WriteLine(MachineId.Length);
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var engineer = _db.Engineers
            // .Include(e => e.Authorizations)
            // .ThenInclude(m => m.Machine)
            .FirstOrDefault(e => e.EngineerId == id);
        return View(engineer);
      }

      public ActionResult Edit(int id)
      {
        var engineer = _db.Engineers.FirstOrDefault(e => e.EngineerId == id);
        ViewBag.Machines = _db.Machines.ToList();
        ViewBag.AuthorizedMachines = _db.EngineerMachine
            .Where(e => e.EngineerId == id)
            .Select(m => m.MachineId)
            .ToList();
        System.Console.WriteLine(ViewBag.AuthorizedMachines.Count);
        return View(engineer);
      }

      [HttpPost]
      public ActionResult Edit(Engineer engineer, int[] MachineId)
      {
        foreach (int m in MachineId)
        {
          if (_db.EngineerMachine.Any(em => 
            em.EngineerId == engineer.EngineerId &&
            em.MachineId == m
          )) continue;
          _db.EngineerMachine.Add(new EngineerMachine() {
            EngineerId = engineer.EngineerId,
            MachineId = m
          });
        }

        _db.Entry(engineer).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        var engineer = _db.Engineers
            .Include(e => e.Authorizations)
            .ThenInclude(m => m.Machine)
            .FirstOrDefault(e => e.EngineerId == id);
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
