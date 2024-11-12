using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<OnlineStoreAdminPanel.OnlineStore.ProductImagesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ProductImagesRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IProductImagesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class ProductImagesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProductImagesSaveHandler
{
    public ProductImagesSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}