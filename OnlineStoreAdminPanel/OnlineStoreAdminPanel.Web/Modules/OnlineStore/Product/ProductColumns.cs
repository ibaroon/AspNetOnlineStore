using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore.Columns;

[ColumnsScript("OnlineStore.Product")]
[BasedOnRow(typeof(ProductRow), CheckNames = true)]
public class ProductColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CatName { get; set; }
    public string Photo { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Quan { get; set; }
}