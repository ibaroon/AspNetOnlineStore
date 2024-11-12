using MyRequest = Serenity.Services.SaveRequest<OnlineStoreAdminPanel.Administration.LanguageRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = OnlineStoreAdminPanel.Administration.LanguageRow;


namespace OnlineStoreAdminPanel.Administration;
public interface ILanguageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
public class LanguageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageSaveHandler
{
    public LanguageSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}