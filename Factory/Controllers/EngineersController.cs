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
        // Save before adding machines or C# will throw an error because
        // it doesn't see the PK for our new Engineer
        _db.Engineers.Add(engineer);
        _db.SaveChanges();

        foreach (int m in MachineId)
        {
          _db.EngineerMachine.Add(new EngineerMachine() {
              EngineerId = engineer.EngineerId,
              MachineId = m
          });
        }
        _db.SaveChanges();

        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var engineer = _db.Engineers
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

        return View(engineer);
      }

      // Delete every relationship that is not passed back on submit, and
      // create any that are passed back that do not already exist.
      //
      // The values that are passed back in MachineId[] represent the total
      // state of relationships between our two entities.
      [HttpPost]
      public ActionResult Edit(Engineer engineer, int[] MachineId)
      {
        // Remove relationships not present in MachineId[]
        _db.EngineerMachine
            .Where(e => e.EngineerId == engineer.EngineerId
                     && !MachineId.Contains(e.MachineId))
            .ToList()
            .ForEach(row => _db.EngineerMachine.Remove(row));

        // Add relationships present in MachineId
        // Can this be done in a LINQ query?
        foreach (int m in MachineId)
        {
          // I'd prefer to attempt to Add the new key without the conditional
          // but in order to catch the exception I would have to pull in other
          // packages (which I'm unwilling to do), or have an overly broad
          // catch (which I am also unwilling to do).
          if (_db.EngineerMachine.Any(em => em.EngineerId == engineer.EngineerId && em.MachineId == m))
          {
            continue;
          }

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
