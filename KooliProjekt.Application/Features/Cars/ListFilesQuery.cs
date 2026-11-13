using System.Collections.Generic;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesQuery : IRequest<OperationResult<IList<string>>>
    {
        public int Id { get; set; }
    }
}
