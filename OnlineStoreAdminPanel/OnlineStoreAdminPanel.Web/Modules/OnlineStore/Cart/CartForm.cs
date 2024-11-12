using Serenity.ComponentModel;

namespace OnlineStoreAdminPanel.OnlineStore.Forms;

[FormScript("OnlineStore.Cart")]
[BasedOnRow(typeof(CartRow), CheckNames = true)]
public class CartForm
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
}