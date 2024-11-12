using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace OnlineStoreAdminPanel.OnlineStore.Pages;

[PageAuthorize(typeof(CartRow))]
public class CartPage : Controller
{
    [Route("OnlineStore/Cart")]
    public ActionResult Index()
    {
        return this.GridPage("@/OnlineStore/Cart/CartPage",
            CartRow.Fields.PageTitle());
    }
}