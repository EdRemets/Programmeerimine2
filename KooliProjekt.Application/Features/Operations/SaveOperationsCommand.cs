using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Operations
{
    public class SaveOperationsCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public decimal? Cost { get; set; }
        public int CarId { get; set; }
        public int OperationTypeId { get; set; }
        public int WorkerId { get; set; }
    }
}
