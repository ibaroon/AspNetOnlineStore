using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CatigoryRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICatigoryDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class CatigoryDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ICatigoryDeleteHandler
{
    public CatigoryDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}