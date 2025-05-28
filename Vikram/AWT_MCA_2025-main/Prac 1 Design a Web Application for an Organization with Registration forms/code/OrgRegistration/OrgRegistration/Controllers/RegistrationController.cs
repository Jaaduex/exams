using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrgRegistration.Models;

namespace OrgRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registration
        public async Task<IActionResult> Index()
        {
              return _context.Registrations != null ? 
                          View(await _context.Registrations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Registrations'  is null.");
        }

        // GET: Registration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registrations == null)
            {
                return NotFound();
            }

            var registrationModel = await _context.Registrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationModel == null)
            {
                return NotFound();
            }

            return View(registrationModel);
        }

        // GET: Registration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,PhoneNumber,Department,Password,ConfirmPassword")] RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationModel);
        }

        // GET: Registration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registrations == null)
            {
                return NotFound();
            }

            var registrationModel = await _context.Registrations.FindAsync(id);
            if (registrationModel == null)
            {
                return NotFound();
            }
            return View(registrationModel);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,PhoneNumber,Department,Password,ConfirmPassword")] RegistrationModel registrationModel)
        {
            if (id != registrationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationModelExists(registrationModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registrationModel);
        }

        // GET: Registration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registrations == null)
            {
                return NotFound();
            }

            var registrationModel = await _context.Registrations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrationModel == null)
            {
                return NotFound();
            }

            return View(registrationModel);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registrations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Registrations'  is null.");
            }
            var registrationModel = await _context.Registrations.FindAsync(id);
            if (registrationModel != null)
            {
                _context.Registrations.Remove(registrationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationModelExists(int id)
        {
          return (_context.Registrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
