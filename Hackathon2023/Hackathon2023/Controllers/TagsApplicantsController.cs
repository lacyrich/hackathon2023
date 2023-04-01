using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hackathon2023.Data;
using Hackathon2023.Models;

namespace Hackathon2023.Controllers
{
    public class TagsApplicantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TagsApplicantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TagsApplicants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TagsApplicants.Include(t => t.Applicants).Include(t => t.Tags);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TagsApplicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TagsApplicants == null)
            {
                return NotFound();
            }

            var tagsApplicants = await _context.TagsApplicants
                .Include(t => t.Applicants)
                .Include(t => t.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagsApplicants == null)
            {
                return NotFound();
            }

            return View(tagsApplicants);
        }

        // GET: TagsApplicants/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "Id", "Id");
            ViewData["TagID"] = new SelectList(_context.Tags, "Id", "Id");
            return View();
        }

        // POST: TagsApplicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagID,ApplicantID")] TagsApplicants tagsApplicants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tagsApplicants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "Id", "Id", tagsApplicants.ApplicantID);
            ViewData["TagID"] = new SelectList(_context.Tags, "Id", "Id", tagsApplicants.TagID);
            return View(tagsApplicants);
        }

        // GET: TagsApplicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TagsApplicants == null)
            {
                return NotFound();
            }

            var tagsApplicants = await _context.TagsApplicants.FindAsync(id);
            if (tagsApplicants == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "Id", "Id", tagsApplicants.ApplicantID);
            ViewData["TagID"] = new SelectList(_context.Tags, "Id", "Id", tagsApplicants.TagID);
            return View(tagsApplicants);
        }

        // POST: TagsApplicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TagID,ApplicantID")] TagsApplicants tagsApplicants)
        {
            if (id != tagsApplicants.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tagsApplicants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsApplicantsExists(tagsApplicants.Id))
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
            ViewData["ApplicantID"] = new SelectList(_context.Applicants, "Id", "Id", tagsApplicants.ApplicantID);
            ViewData["TagID"] = new SelectList(_context.Tags, "Id", "Id", tagsApplicants.TagID);
            return View(tagsApplicants);
        }

        // GET: TagsApplicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TagsApplicants == null)
            {
                return NotFound();
            }

            var tagsApplicants = await _context.TagsApplicants
                .Include(t => t.Applicants)
                .Include(t => t.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagsApplicants == null)
            {
                return NotFound();
            }

            return View(tagsApplicants);
        }

        // POST: TagsApplicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TagsApplicants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TagsApplicants'  is null.");
            }
            var tagsApplicants = await _context.TagsApplicants.FindAsync(id);
            if (tagsApplicants != null)
            {
                _context.TagsApplicants.Remove(tagsApplicants);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagsApplicantsExists(int id)
        {
          return (_context.TagsApplicants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
