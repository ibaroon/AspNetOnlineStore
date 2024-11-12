using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<OnlineStoreAdminPanel.OnlineStore.ProductImagesRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ProductImagesRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IProductImagesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class ProductImagesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProductImagesRetrieveHandler
{
    public ProductImagesRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}