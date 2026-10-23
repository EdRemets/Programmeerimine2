using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Workers
{
    public class ListWorkersQuery : IRequest<OperationResult<PagedResult<WorkerListItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
