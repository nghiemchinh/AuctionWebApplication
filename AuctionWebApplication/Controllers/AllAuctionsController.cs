using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionWebApplication;
using Microsoft.AspNetCore.Authorization;

namespace AuctionWebApplication.Controllers
{
    [Authorize(Roles ="admin")]
    public class AllAuctionsController : Controller
    {
        private readonly DbauctionContext _context;

        public AllAuctionsController(DbauctionContext context)
        {
            _context = context;
        }

        // GET: AllAuctions
        public async Task<IActionResult> Index(string searchname)
        {
     
            var dbauctionContext = _context.Auctions.Include(a => a.Bid).Include(a => a.Seller).Include(a => a.Category);
            return View(await dbauctionContext.ToListAsync());
        }

        // GET: AllAuctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Bid)
                .Include(a => a.Seller)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AuctionId == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // GET: AllAuctions/Create
        public IActionResult Create()
        {
            ViewData["BidId"] = new SelectList(_context.Bids, "BidId", "BidId");
            ViewData["SellerId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: AllAuctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuctionId,SellerId,AuctionName,AuctionDesription,StartPrice,CategoryId,EndTime,BidId")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BidId"] = new SelectList(_context.Bids, "BidId", "BidId", auction.BidId);
            ViewData["SellerId"] = new SelectList(_context.Users, "UserId", "UserId", auction.SellerId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", auction.CategoryId);
            return View(auction);
        }

        // GET: AllAuctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }
            ViewData["BidId"] = new SelectList(_context.Bids, "BidId", "BidId", auction.BidId);
            ViewData["SellerId"] = new SelectList(_context.Users, "UserId", "UserId", auction.SellerId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", auction.CategoryId);
            return View(auction);
        }

        // POST: AllAuctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuctionId,SellerId,AuctionName,AuctionDesription,StartPrice,CategoryId,EndTime,Image,BidId")] Auction auction, IFormFile file)
        {
            if (id != auction.AuctionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.Auctions == null)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string file_path = Path.Combine(Directory.GetCurrentDirectory(),
                            @"wwwroot/update", filename);
                        using (var stream = new FileStream(file_path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        auction.Image = "update/" + filename;

                        _context.Update(auction);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionExists(auction.AuctionId))
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
            ViewData["BidId"] = new SelectList(_context.Bids, "BidId", "BidId", auction.BidId);
            ViewData["SellerId"] = new SelectList(_context.Users, "UserId", "UserId", auction.SellerId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", auction.CategoryId);
            return View(auction);
        }

        // GET: AllAuctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Bid)
                .Include(a => a.Seller)
                .FirstOrDefaultAsync(m => m.AuctionId == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // POST: AllAuctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Auctions == null)
            {
                return Problem("Entity set 'DbauctionContext.Auctions'  is null.");
            }

            var auction = await _context.Auctions.FindAsync(id);
            var soldItem = await _context.SoldItems.FindAsync(auction.AuctionId);
            if (soldItem != null) {
                _context.SoldItems.Remove(soldItem);
            }
            if (auction != null)
            {
                _context.Auctions.Remove(auction);
           }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionExists(int id)
        {
          return (_context.Auctions?.Any(e => e.AuctionId == id)).GetValueOrDefault();
        }
    }
}
