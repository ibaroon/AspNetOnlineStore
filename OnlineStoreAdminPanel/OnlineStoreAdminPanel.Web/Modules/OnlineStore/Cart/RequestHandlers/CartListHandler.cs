using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.OnlineStore.CartRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CartRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICartListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class CartListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ICartListHandler
{
    public CartListHandler(IRequestContext context)
            : base(context)
    {
    }
}