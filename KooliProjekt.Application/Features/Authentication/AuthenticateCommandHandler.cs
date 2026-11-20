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

            if (worker == null ||
                string.IsNullOrEmpty(worker.passwordHash) ||
                !PasswordHelper.Verify(request.Password, worker.passwordHash))
            {
                result.AddError(InvalidCredentialsError);
                return result;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, worker.id.ToString()),
                new Claim(ClaimTypes.Name, worker.userName)
            };

            if (worker.isAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            result.Value = _tokenBuilder.GenerateToken(claims.ToArray());

            return result;
        }
    }
}
