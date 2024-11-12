using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace OnlineStoreAdminPanel.OnlineStore.Pages;

[PageAuthorize(typeof(CatigoryRow))]
public class CatigoryPage : Controller
{
    [Route("OnlineStore/Catigory")]
    public ActionResult Index()
    {
        return this.GridPage("@/OnlineStore/Catigory/CatigoryPage",
            CatigoryRow.Fields.PageTitle());
    }
}