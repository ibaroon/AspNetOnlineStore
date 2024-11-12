using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace OnlineStoreAdminPanel.OnlineStore.Pages;

[PageAuthorize(typeof(ProductImagesRow))]
public class ProductImagesPage : Controller
{
    [Route("OnlineStore/ProductImages")]
    public ActionResult Index()
    {
        return this.GridPage("@/OnlineStore/ProductImages/ProductImagesPage",
            ProductImagesRow.Fields.PageTitle());
    }
}