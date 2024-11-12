using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<OnlineStoreAdminPanel.OnlineStore.CatigoryRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CatigoryRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICatigoryRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class CatigoryRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ICatigoryRetrieveHandler
{
    public CatigoryRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}