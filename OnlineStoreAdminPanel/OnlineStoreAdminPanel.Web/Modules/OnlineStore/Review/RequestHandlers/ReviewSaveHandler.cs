using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<OnlineStoreAdminPanel.OnlineStore.ReviewRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ReviewRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IReviewSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class ReviewSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IReviewSaveHandler
{
    public ReviewSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}