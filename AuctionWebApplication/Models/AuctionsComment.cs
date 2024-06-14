namespace AuctionWebApplication.Models
{
    public class AuctionsComment
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime? CommentOn { get; set; }
        public int? AuctionId { get; set; }
        public int? Rating { get; set; }

        public virtual Auction? Auction { get; set; }
    }
}
