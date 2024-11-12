using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<OnlineStoreAdminPanel.OnlineStore.ProductRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ProductRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IProductRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class ProductRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IProductRetrieveHandler
{
    public ProductRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}