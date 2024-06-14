using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuctionWebApplication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AuctionWebApplication.Controllers
{
    public class MyAuctionsController : Controller
    {
        private readonly DbauctionContext _context;

        public MyAuctionsController(DbauctionContext context)
        {
            _context = context;
        }

        // GET: MyAuctions
        public async Task<IActionResult> Index(string searchString)
        {
            var myAuction = from p in _context.Auctions
                         select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                var MyAuction = myAuction.Where(s => s.AuctionName.Contains(searchString));
                return View(await MyAuction.ToListAsync());
            }
            var dbauctionContext = _context.Auctions
                .Include(a => a.Seller)
                .Include(a => a.Bid)
                .Include(a => a.Category)
                .Where(a => a.SellerId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(await dbauctionContext.ToListAsync());
        }

        // GET: MyAuctions/Details/5
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

        // GET: MyAuctions/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: MyAuctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuctionId,SellerId,AuctionName,AuctionDesription,StartPrice,EndTime,CategoryId,Image,BidId")] Auction auction, IFormFile file)
        {
            string filename = Path.GetFileName(file.FileName);
            string file_path = Path.Combine(Directory.GetCurrentDirectory(),
                @"wwwroot/update", filename);
            using (var stream = new FileStream(file_path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            auction.Image = "update/" + filename;

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            auction.SellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Add(auction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Auctions");
        }
        // GET: MyAuctions/Edit/5
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

        // POST: MyAuctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuctionId,SellerId,AuctionName,AuctionDesription,StartPrice,CategoryId,Image,EndTime,BidId")] Auction auction, IFormFile file)
        {
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
            return View(auction);
        }

        // GET: MyAuctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: MyAuctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auctions == null)
            {
                return Problem("Entity set 'DbauctionContext.Auctions'  is null.");
            }
            var auction = await _context.Auctions.FindAsync(id);
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
