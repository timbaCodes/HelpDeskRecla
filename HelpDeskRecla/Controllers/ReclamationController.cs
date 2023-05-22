using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk2023.Models;
using HelpDeskIdentity.Models.HelpDeskModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HelpDeskRecla.Controllers
{
    [Authorize]
    public class ReclamationController : Controller
    {
        private readonly DeskDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReclamationController(DeskDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reclamation
        /*public async Task<IActionResult> Index()
        {
            // Get the currently logged-in user
            var user = await _userManager.GetUserAsync(User);

            // Filter the reclamation entities based on the logged-in user
            var reclamationEntities = await _context.Reclamation
                .Where(r => r.ComplainedBy == user.Id)
                .ToListAsync();

            return View(reclamationEntities);
        }*/
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (await _userManager.IsInRoleAsync(user, "Technician"))
            {
                // If the user has the "Technician" role, retrieve all reclamations
                var reclamationEntities = await _context.Reclamation.ToListAsync();
                return View(reclamationEntities);
            }
            else
            {
                // If the user doesn't have the "Technician" role, retrieve their own reclamations
                var userReclamationEntities = await _context.Reclamation
                    .Where(r => r.ComplainedBy == user.Id)
                    .ToListAsync();
                return View(userReclamationEntities);
            }
        }
        // GET: Reclamation/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Reclamation == null)
            {
                return NotFound();
            }

            var reclamationEntity = await _context.Reclamation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclamationEntity == null)
            {
                return NotFound();
            }

            return View(reclamationEntity);
        }

        // GET: Reclamation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ComplainedBy,ContactNo,Email,ComplainType,ComplainTo,Title,Description,ComplainTime,IsResolved,Reference")] ReclamationEntity reclamationEntity)
        {
            if (ModelState.IsValid)
            {
                reclamationEntity.Id = Guid.NewGuid();

                // Set the user who created the reclamation
                var user = await _userManager.GetUserAsync(User);
                reclamationEntity.ComplainedBy = user.Id;

                _context.Add(reclamationEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(reclamationEntity);
        }

        // GET: Reclamation/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Reclamation == null)
            {
                return NotFound();
            }

            var reclamationEntity = await _context.Reclamation.FindAsync(id);
            if (reclamationEntity == null)
            {
                return NotFound();
            }
            return View(reclamationEntity);
        }

        // POST: Reclamation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ComplainedBy,ContactNo,Email,ComplainType,ComplainTo,Title,Description,ComplainTime,IsResolved,Reference")] ReclamationEntity reclamationEntity)
        {
            if (id != reclamationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamationEntityExists(reclamationEntity.Id))
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
            return View(reclamationEntity);
        }

        // GET: Reclamation/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Reclamation == null)
            {
                return NotFound();
            }

            var reclamationEntity = await _context.Reclamation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclamationEntity == null)
            {
                return NotFound();
            }

            return View(reclamationEntity);
        }

        // POST: Reclamation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Reclamation == null)
            {
                return Problem("Entity set 'DeskDbContext.Reclamation'  is null.");
            }
            var reclamationEntity = await _context.Reclamation.FindAsync(id);
            if (reclamationEntity != null)
            {
                _context.Reclamation.Remove(reclamationEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamationEntityExists(Guid id)
        {
          return (_context.Reclamation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
