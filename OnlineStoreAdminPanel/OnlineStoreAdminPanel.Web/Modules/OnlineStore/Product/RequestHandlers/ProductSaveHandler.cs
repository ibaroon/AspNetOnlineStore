using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<OnlineStoreAdminPanel.OnlineStore.ProductRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ProductRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IProductSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class ProductSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProductSaveHandler
{
    public ProductSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}