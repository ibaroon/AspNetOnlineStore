using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.OnlineStore.ReviewRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ReviewRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IReviewListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class ReviewListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IReviewListHandler
{
    public ReviewListHandler(IRequestContext context)
            : base(context)
    {
    }
}