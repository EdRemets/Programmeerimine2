using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Workers
{
    public class GetWorkersQuery : IRequest<Worker>
    {
        public int Id { get; set; }
    }
}
