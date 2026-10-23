using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Workers
{
    public class GetWorkersQuery : IRequest<OperationResult<WorkerDto>>
    {
        public int Id { get; set; }
    }
}
