using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flash_card.Data;
using flash_card.Models;

namespace flash_card.Controllers
{
    public class WordsController : Controller
    {
        private readonly FlashCardContext _context;

        public WordsController(FlashCardContext context)
        {
            _context = context;
        }

        // GET: Words
        public async Task<IActionResult> Index()
        {
              return _context.Word != null ? 
                          View(await _context.Word.ToListAsync()) :
                          Problem("Entity set 'FlashCardContext.Word'  is null.");
        }

        // GET: Words/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Word == null)
            {
                return NotFound();
            }

            var word = await _context.Word
                .FirstOrDefaultAsync(m => m.Id == id);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // GET: Words/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Defination,Example")] Word word)
        {
            if (ModelState.IsValid)
            {
                word.CreateDate = DateTime.Now.Date.ToString();
                word.LearnTime = 0;
                _context.Add(word);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(word);
        }

        // GET: Words/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Word == null)
            {
                return NotFound();
            }

            var word = await _context.Word.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title,Defination,Example, CreateDate, LearnTime")] Word word)
        {
            if (id != word.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {   
                    _context.Update(word); 
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WordExists(word.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Content("Not update") ;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(word);
        }

        // GET: Words/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Word == null)
            {
                return NotFound();
            }

            var word = await _context.Word
                .FirstOrDefaultAsync(m => m.Id == id);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Word == null)
            {
                return Problem("Entity set 'FlashCardContext.Word'  is null.");
            }
            var word = await _context.Word.FindAsync(id);
            if (word != null)
            {
                _context.Word.Remove(word);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WordExists(int id)
        {
          return (_context.Word?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
