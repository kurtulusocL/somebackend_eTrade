using MediatR;

namespace eTrade.Business.CQRS.Features.Queries.GetAllPoducts
{
    public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        //public Pagination Pagination { get; set; }
        public int Size { get; set; } = 0;
        public int Page { get; set; } = 5;
    }
}
