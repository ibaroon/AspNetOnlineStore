using System;
using System.Collections.Generic;

namespace OnlineStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? PayMeth { get; set; }

    public string? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? OrderSts { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
