using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dev_hospital1.Data;
using dev_hospital1.Models;

namespace dev_hospital1.Controllers
{
    public class RegistersController : Controller
    {
        private readonly devhospital1 _context;

        public RegistersController(devhospital1 context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
              return _context.Registers != null ? 
                          View(await _context.Registers.ToListAsync()) :
                          Problem("Entity set 'devhospital1.Registers'  is null.");
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Password")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,Password")] Register register)
        {
            if (id != register.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Id))
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
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registers == null)
            {
                return Problem("Entity set 'devhospital1.Registers'  is null.");
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
          return (_context.Registers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
