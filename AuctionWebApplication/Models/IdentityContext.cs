using AuctionWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionWebApplication
{
    public class IdentityContext : IdentityDbContext<UserIdent>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-8LFSKBRB\\SA;Database=DBAuction; Trusted_Connection=True; Trust Server Certificate=True;");
    }
}
