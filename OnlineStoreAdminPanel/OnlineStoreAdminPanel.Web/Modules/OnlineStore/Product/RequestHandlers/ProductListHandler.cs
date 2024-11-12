using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.OnlineStore.ProductRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ProductRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IProductListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class ProductListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProductListHandler
{
    public ProductListHandler(IRequestContext context)
            : base(context)
    {
    }
}