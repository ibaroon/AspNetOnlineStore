using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<OnlineStoreAdminPanel.OnlineStore.CatigoryRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CatigoryRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICatigorySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class CatigorySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ICatigorySaveHandler
{
    public CatigorySaveHandler(IRequestContext context)
            : base(context)
    {
    }
}