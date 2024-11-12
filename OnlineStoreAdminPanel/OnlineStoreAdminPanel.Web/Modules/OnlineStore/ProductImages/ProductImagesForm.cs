using Serenity.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore.Forms;

[FormScript("OnlineStore.ProductImages")]
[BasedOnRow(typeof(ProductImagesRow), CheckNames = true)]
public class ProductImagesForm
{
    public int ProductId { get; set; }
    public string Image { get; set; }
}