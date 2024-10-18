using System;
using System.Collections.Generic;

namespace FoodCourtData.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
