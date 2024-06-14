using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionWebApplication.Models;

public partial class SoldItem
{
    public int AuctionId { get; set; }

    [Display(Name = "Final price")]
    public decimal? FinalPrice { get; set; }

    public string BidderId { get; set; } = null!;

    [Display(Name = "Auction")]
    public virtual Auction Auction { get; set; } = null!;

    [Display(Name = "Buyer")]
    public virtual User Bidder { get; set; } = null!;
}
