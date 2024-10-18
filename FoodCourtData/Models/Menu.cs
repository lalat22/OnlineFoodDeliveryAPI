using System;
using System.Collections.Generic;

namespace FoodCourtData.Models;

public partial class Menu
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? CategoryId { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }
}
