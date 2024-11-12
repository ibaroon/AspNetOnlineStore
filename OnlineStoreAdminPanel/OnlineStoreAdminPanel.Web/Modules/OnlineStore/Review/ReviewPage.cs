using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace OnlineStoreAdminPanel.OnlineStore.Pages;

[PageAuthorize(typeof(ReviewRow))]
public class ReviewPage : Controller
{
    [Route("OnlineStore/Review")]
    public ActionResult Index()
    {
        return this.GridPage("@/OnlineStore/Review/ReviewPage",
            ReviewRow.Fields.PageTitle());
    }
}