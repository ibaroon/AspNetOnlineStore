using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.OnlineStore.CatigoryRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CatigoryRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICatigoryListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class CatigoryListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ICatigoryListHandler
{
    public CatigoryListHandler(IRequestContext context)
            : base(context)
    {
    }
}