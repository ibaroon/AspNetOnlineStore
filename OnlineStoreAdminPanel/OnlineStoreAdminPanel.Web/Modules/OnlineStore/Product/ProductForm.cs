using Serenity.ComponentModel;
using System;

namespace OnlineStoreAdminPanel.OnlineStore.Forms;

[FormScript("OnlineStore.Product")]
[BasedOnRow(typeof(ProductRow), CheckNames = true)]
public class ProductForm
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CatId { get; set; }
    public string Photo { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Quan { get; set; }
}