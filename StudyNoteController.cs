using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyPlanner.Data;
using StudyPlanner.Models;

namespace StudyPlanner.Controllers
{
    public class StudyNoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyNoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var studyNotes = await _context.StudyNotes
                .Include(n => n.Course)
                .ToListAsync();

            return View(studyNotes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudyNote studyNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(studyNote);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyNote = await _context.StudyNotes
                .Include(n => n.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (studyNote == null)
            {
                return NotFound();
            }

            return View(studyNote);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyNote = await _context.StudyNotes.FindAsync(id);

            if (studyNote == null)
            {
                return NotFound();
            }

            return View(studyNote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudyNote studyNote)
        {
            if (id != studyNote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.StudyNotes.Any(e => e.Id == studyNote.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(studyNote);
        }
    }
}