using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Workers
{
    public class SaveWorkersCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
