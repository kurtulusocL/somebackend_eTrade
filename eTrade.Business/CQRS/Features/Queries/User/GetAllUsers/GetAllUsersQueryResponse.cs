﻿

namespace eTrade.Business.CQRS.Features.Queries.User.GetAllUsers
{
    public class GetAllUsersQueryResponse
    {
        public object Users { get; set; }
        public int TotalUsersCount { get; set; }
    }
}
