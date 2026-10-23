using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationsQuery : IRequest<OperationResult<OperationDto>>
    {
        public int Id { get; set; }
    }
}