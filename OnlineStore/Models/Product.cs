using System;
using System.Collections.Generic;

namespace OnlineStore.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Price { get; set; }

    public int? CatId { get; set; }

    public string? Photo { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Catigory? Cat { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
