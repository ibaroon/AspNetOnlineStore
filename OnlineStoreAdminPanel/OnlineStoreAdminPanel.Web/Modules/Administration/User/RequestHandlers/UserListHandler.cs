using MyRequest = OnlineStoreAdminPanel.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<OnlineStoreAdminPanel.Administration.UserRow>;
using MyRow = OnlineStoreAdminPanel.Administration.UserRow;

namespace OnlineStoreAdminPanel.Administration;
public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
{
    public UserListHandler(IRequestContext context)
         : base(context)
    {
    }
}