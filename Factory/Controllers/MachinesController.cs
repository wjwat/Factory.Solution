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
        ViewBag.Engineers = _db.Engineers.ToList();
        return View();
      }

      [HttpPost]
      public ActionResult Create(Machine machine, int[] EngineerId)
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();

        foreach (int e in EngineerId)
        {
          _db.EngineerMachine.Add(new EngineerMachine() {
              MachineId = machine.MachineId,
              EngineerId = e
          });
        }
        _db.SaveChanges();

        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var machine = _db.Machines
            .FirstOrDefault(e => e.MachineId == id);
        return View(machine);
      }

      public ActionResult Edit(int id)
      {
        var machine = _db.Machines.FirstOrDefault(e => e.MachineId == id);
        ViewBag.Engineers = _db.Engineers.ToList();
        ViewBag.AuthorizedEngineers = _db.EngineerMachine
            .Where(e => e.MachineId == id)
            .Select(m => m.EngineerId)
            .ToList();

        return View(machine);
      }

      [HttpPost]
      public ActionResult Edit(Machine machine, int[] EngineerId)
      {
        _db.EngineerMachine
            .Where(m => m.MachineId == machine.MachineId
                     && !EngineerId.Contains(m.EngineerId))
            .ToList()
            .ForEach(row => _db.EngineerMachine.Remove(row));

        foreach (int e in EngineerId)
        {
          if (_db.EngineerMachine.Any(em => em.EngineerId == e && em.MachineId == machine.MachineId))
          {
            continue;
          }

          _db.EngineerMachine.Add(new EngineerMachine() {
              EngineerId = e,
              MachineId = machine.MachineId
          });
        }

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
