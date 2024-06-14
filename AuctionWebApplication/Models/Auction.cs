using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AuctionWebApplication.Models;

namespace AuctionWebApplication;

public partial class Auction
{
    public int AuctionId { get; set; }

    public string SellerId { get; set; } = null!;

    [Display(Name = "Name")]
    public string AuctionName { get; set; } = null!;

    [Display(Name = "Description")]
    public string? AuctionDesription { get; set; }

    [Display(Name = "Initial price")]
    public decimal StartPrice { get; set; }

    [Display(Name = "End time")]
    public DateTime EndTime { get; set; }

    public string? Image { get; set; }
    public string? CategoryId { get; set; }
    public int? BidId { get; set; }

    [Display(Name = "Buyer")]
    public virtual Bid? Bid { get; set; }

    [Display(Name = "Seller")]
    public virtual User Seller { get; set; } = null!;
    public virtual Category? Category { get; set; }
    public virtual SoldItem? SoldItem { get; set; }

    public virtual ICollection<AuctionsComment> AuctionsComments { get; set; }
}
