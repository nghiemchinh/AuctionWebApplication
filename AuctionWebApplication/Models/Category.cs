namespace AuctionWebApplication.Models
{
    public class Category
    {
        public Category()
        {
            Auctions = new HashSet<Auction>();
        }

        public string CategoryId { get; set; } = null!;

        public virtual ICollection<Auction> Auctions { get; set; }
    }
}
