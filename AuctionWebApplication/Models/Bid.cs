using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionWebApplication;

public partial class Bid
{

  
    [Display(Name = "Auction")]
    public int AuctionId { get; set; }

    public string BidderId { get; set; } = null!;

    [Display(Name = "Price")]
    public decimal Price { get; set; }

    public int BidId { get; set; }

    [Display(Name = "Bid time")]
    public DateTime BidTime { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    [Display(Name = "Counterparty")]
    public virtual User Bidder { get; set; } = null!;
}
