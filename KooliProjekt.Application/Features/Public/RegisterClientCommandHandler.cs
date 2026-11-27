using KooliProjekt.Application.Authentication;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Public
{
    public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, OperationResult<int?>>
    {
        private readonly ApplicationDbContext _dbContext;

        public RegisterClientCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int?>> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<int?>();

            var client = new Client
            {
                name = request.Name,
                email = request.Email,
                phone = request.Phone,
                userName = request.UserName,
                passwordHash = PasswordHelper.Hash(request.Password)
            };

            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync(cancellationToken);

            result.Value = client.id;

            return result;
        }
    }
}
