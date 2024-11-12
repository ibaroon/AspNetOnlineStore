using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<OnlineStoreAdminPanel.OnlineStore.CartRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CartRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICartSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class CartSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ICartSaveHandler
{
    public CartSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}