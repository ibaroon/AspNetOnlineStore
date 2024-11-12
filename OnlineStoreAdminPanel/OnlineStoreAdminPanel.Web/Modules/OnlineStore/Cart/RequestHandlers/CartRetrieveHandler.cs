﻿using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<OnlineStoreAdminPanel.OnlineStore.CartRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.CartRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface ICartRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class CartRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ICartRetrieveHandler
{
    public CartRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}