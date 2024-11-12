using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.OnlineStore.ProductImagesRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ProductImagesRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IProductImagesListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class ProductImagesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IProductImagesListHandler
{
    public ProductImagesListHandler(IRequestContext context)
            : base(context)
    {
    }
}