using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Operations
{
    public class ListOperationQuery : IRequest<IEnumerable<Operation>>
    {

    }
}
