using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuctionWebApplication.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly DbauctionContext _context;

        public AuctionsController(DbauctionContext context)
        {
            _context = context;
        }
        // GET: Auctions
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
                .Where(a => a.EndTime > DateTime.Now);
            return View(await dbauctionContext.ToListAsync());
        }

        // GET: Auctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
			if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Seller)
                .Include(a =>a.Bid).Where(a => a.EndTime > DateTime.Now)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AuctionId == id);
            if (auction == null)
            {
                return NotFound();
            }
            ViewBag.AuctionId = id.Value;

            var comments = _context.AuctionsComments.Where(d => d.AuctionId.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;

            var ratings = _context.AuctionsComments.Where(d => d.AuctionId.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }
            return View(auction);
        }
        [Authorize(Roles = "admin")]
        // GET: Auctions/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Auctions/Create
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
            return RedirectToAction(nameof(Index), "AllAuctions");
        }

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

        // POST: Auctions/Edit/5
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

        [HttpPost]
        public async Task<IActionResult> Details(int id, int bet)
        {
            var newUser = _context.Users.Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var currentBid = await _context.Bids.FindAsync(auction.BidId);
            if (newUser== null) 
            {
                return RedirectToAction("Login", "Account");
                /*  TempData["ErrorMessage"] += "Only authorized users can place a bet" + "<br>";*/
            }
            else if (auction.SellerId== User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                TempData["ErrorMessage"] += "It is not possible to bid on your auction" + "<br>";
            }
            else if (bet > newUser.Balance - newUser.Freeze)
            {
                TempData["ErrorMessage"] += "Insufficient balance to place a bet" + "<br>";
            }
            else if (currentBid == null && bet < auction.StartPrice)
            {
                TempData["ErrorMessage"] += "The bid must be greater than the opening price" + "<br>";
            }
            else if (currentBid==null || bet > currentBid.Price )
            {
                if (currentBid != null)
                {
                    var curUser = _context.Users.Where(c => c.UserId == currentBid.BidderId).FirstOrDefault();
                    curUser.Freeze -= currentBid.Price;
                    _context.Update(curUser);
                }
                var bid = new Bid
                {
                    AuctionId = id,
                    BidderId = newUser.UserId,
                    Price = bet,
                    BidTime = DateTime.Now
                };
                
                newUser.Freeze += bet;
                _context.Update(newUser);
                _context.Bids.Add(bid);
                _context.SaveChanges();
                auction.BidId = bid.BidId;
                auction.Bid = bid;
                _context.Update(auction);
                _context.SaveChanges();
            }
            else if (bet <= currentBid.Price)
            {
               TempData["ErrorMessage"] += "The bid must be greater than the last bid" + "<br>";
            }
            
            return View(auction);
        }
       
    
        // GET: Auctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.Seller)
                .Include(a => a.Bid).Where(a => a.EndTime > DateTime.Now)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AuctionId == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // POST: Auctions/Delete/5
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
