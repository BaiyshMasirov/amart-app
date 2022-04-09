using Amart.Application.Common.Interfaces;
using Amart.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amart.Application.MediatR.Accounts.Commands
{
    public class LoginCommand : IRequest<Result>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result>
    {
        private readonly IAmartEFContext _context;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(IAmartEFContext context,
                                   ILogger<LoginCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Login == command.Login).FirstOrDefaultAsync(cancellationToken);

                if (user == null)
                    return Result.Failure("User not found, login  incorrect");

                var passwordIsValid = user.Password.Equals(command.Password);

                if (!passwordIsValid)
                    return Result.Failure("Password  incorrect");

                return Result.Success(user.Id.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError($"User authorize failed with error: {ex.Message}");
                return Result.Failure("Error");
            }
        }
    }
}