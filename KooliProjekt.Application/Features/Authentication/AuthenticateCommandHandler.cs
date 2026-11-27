using KooliProjekt.Application.Authentication;
using KooliProjekt.Application.Authentication.Jwt;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Features.Authentication
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, OperationResult<string>>
    {
        private const string InvalidCredentialsError = "Invalid username or password.";

        private readonly ApplicationDbContext _dbContext;
        private readonly JwtTokenBuilder _tokenBuilder;

        public AuthenticateCommandHandler(ApplicationDbContext dbContext, JwtTokenBuilder tokenBuilder)
        {
            _dbContext = dbContext;
            _tokenBuilder = tokenBuilder;
        }

        public async Task<OperationResult<string>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();

            var worker = await _dbContext.Workers
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.userName == request.UserName, cancellationToken);

            if (worker != null &&
                !string.IsNullOrEmpty(worker.passwordHash) &&
                PasswordHelper.Verify(request.Password, worker.passwordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, worker.id.ToString()),
                    new Claim(ClaimTypes.Name, worker.userName),
                    new Claim(ClaimTypes.Role, "Worker")
                };

                if (worker.isAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }

                result.Value = _tokenBuilder.GenerateToken(claims.ToArray());
                return result;
            }

            var client = await _dbContext.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.userName == request.UserName, cancellationToken);

            if (client != null &&
                !string.IsNullOrEmpty(client.passwordHash) &&
                PasswordHelper.Verify(request.Password, client.passwordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, client.id.ToString()),
                    new Claim(ClaimTypes.Name, client.userName),
                    new Claim(ClaimTypes.Role, "Client")
                };

                result.Value = _tokenBuilder.GenerateToken(claims.ToArray());
                return result;
            }

            result.AddError(InvalidCredentialsError);
            return result;
        }
    }
}
