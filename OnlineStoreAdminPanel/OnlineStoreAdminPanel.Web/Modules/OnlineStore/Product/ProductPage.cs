using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace OnlineStoreAdminPanel.OnlineStore.Pages;

[PageAuthorize(typeof(ProductRow))]
public class ProductPage : Controller
{
    [Route("OnlineStore/Product")]
    public ActionResult Index()
    {
        return this.GridPage("@/OnlineStore/Product/ProductPage",
            ProductRow.Fields.PageTitle());
    }
}