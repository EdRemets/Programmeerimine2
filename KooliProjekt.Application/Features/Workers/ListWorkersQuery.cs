using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Workers
{
    public class ListWorkersQuery : IRequest<IEnumerable<Worker>>
    {
    }
}
