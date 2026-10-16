using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypesQuery : IRequest<OperationType>
    {
        public int Id { get; set; }
    }
}
