﻿using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<OnlineStoreAdminPanel.OnlineStore.ReviewRow>;
using MyRow = OnlineStoreAdminPanel.OnlineStore.ReviewRow;

namespace OnlineStoreAdminPanel.OnlineStore;

public interface IReviewRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class ReviewRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IReviewRetrieveHandler
{
    public ReviewRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}