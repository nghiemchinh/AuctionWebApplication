using AuctionWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AuctionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbauctionContext _context;

        public HomeController(DbauctionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Auctionname)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            if (!String.IsNullOrEmpty(Auctionname))
            {
                var orderList = from o in _context.Auctions select o;
                orderList = orderList.Where(o => o.CategoryId.Equals(Auctionname));
                if (orderList != null)
                {
                    return View(await orderList.ToListAsync());
                }
                else
                {
                    Problem("Entity set 'OrderDbContext.Orders'  is null.");
                }
            }
            var dbauctionContext = _context.Auctions
             .Include(a => a.Seller)
             .Include(a => a.Bid)
             .Include(a => a.Category)
             .Where(a => a.EndTime > DateTime.Now);

            return View(await dbauctionContext.ToListAsync());
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}