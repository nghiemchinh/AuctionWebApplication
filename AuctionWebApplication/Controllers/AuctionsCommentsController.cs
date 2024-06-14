using AuctionWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AuctionWebApplication.Controllers
{
    public class AuctionsCommentsController : Controller
    {
        private readonly DbauctionContext _context;

        public AuctionsCommentsController(DbauctionContext context)
        {
            _context = context;
        }
         [Authorize(Roles = "admin")]
        // GET: AuctionsComments
        public async Task<IActionResult> Index()
        {
            var auctionratingContext = _context.AuctionsComments.Include(a => a.Auction);
            return View(await auctionratingContext.ToListAsync());
        }

        // GET: AuctionsComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuctionsComments == null)
            {
                return NotFound();
            }

            var auctionsComment = await _context.AuctionsComments
                .Include(a => a.Auction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auctionsComment == null)
            {
                return NotFound();
            }

            return View(auctionsComment);
        }


        // GET: AuctionsComments/Create
        public IActionResult Create()
        {
            ViewData["AuctionId"] = new SelectList(_context.Auctions, "AuctionId", "AuctionId");
            return View();
        }

        // POST: AuctionsComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment,CommentOn,AuctionId,Rating")] AuctionsComment auctionsComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auctionsComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Auctions");
            }
            ViewData["AuctionId"] = new SelectList(_context.Auctions, "AuctionId", "AuctionId", auctionsComment.AuctionId);
            return View(auctionsComment);
        }

        // GET: AuctionsComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuctionsComments == null)
            {
                return NotFound();
            }

            var auctionsComment = await _context.AuctionsComments.FindAsync(id);
            if (auctionsComment == null)
            {
                return NotFound();
            }
            ViewData["AuctionId"] = new SelectList(_context.Auctions, "AuctionId", "AuctionId", auctionsComment.AuctionId);
            return View(auctionsComment);
        }

        // POST: AuctionsComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,CommentOn,AuctionId,Rating")] AuctionsComment auctionsComment)
        {
            if (id != auctionsComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auctionsComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionsCommentExists(auctionsComment.Id))
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
            ViewData["AuctionId"] = new SelectList(_context.Auctions, "AuctionId", "AuctionId", auctionsComment.AuctionId);
            return View(auctionsComment);
        }

        // GET: AuctionsComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuctionsComments == null)
            {
                return NotFound();
            }

            var auctionsComment = await _context.AuctionsComments
                .Include(a => a.Auction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auctionsComment == null)
            {
                return NotFound();
            }

            return View(auctionsComment);
        }

        // POST: AuctionsComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuctionsComments == null)
            {
                return Problem("Entity set 'auctionratingContext.AuctionsComments'  is null.");
            }
            var auctionsComment = await _context.AuctionsComments.FindAsync(id);
            if (auctionsComment != null)
            {
                _context.AuctionsComments.Remove(auctionsComment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionsCommentExists(int id)
        {
            return (_context.AuctionsComments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
