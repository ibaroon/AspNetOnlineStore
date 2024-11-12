using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.Administration.LanguageRow>;
using MyRow = OnlineStoreAdminPanel.Administration.LanguageRow;


namespace OnlineStoreAdminPanel.Administration;
public interface ILanguageListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LanguageListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageListHandler
{
    public LanguageListHandler(IRequestContext context)
         : base(context)
    {
    }
}