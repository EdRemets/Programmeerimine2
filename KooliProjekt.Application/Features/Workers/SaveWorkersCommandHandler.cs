using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Workers
{
    public class SaveWorkersCommandHandler : IRequestHandler<SaveWorkersCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveWorkersCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveWorkersCommand request, CancellationToken cancellationToken)
        {
            var worker = new Worker();

            if (request.Id == 0)
            {
                _dbContext.Add(worker);
            }
            else
            {
                worker = await _dbContext.FindAsync<Worker>(request.Id);
            }

            worker.name = request.Name;
            worker.isAdmin = request.IsAdmin;

            await _dbContext.SaveChangesAsync();

            return new OperationResult();
        }
    }
}
