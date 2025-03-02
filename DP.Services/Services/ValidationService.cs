using DP.Core.Entities;
using DP.Infrastructure.Data;
using DP.Services.Interfaces;
using DP.Services.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DP.Services.Services
{
    public class ValidationService : IValidationService, IValidationServiceGeneric
    {
        private readonly AppDbContext _context;
        private readonly IUserContext _userContext;
        public ValidationService(AppDbContext context, IUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task CheckUsernameExistsAsync(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                throw new CustomException("Username already exists.");
            }
        }

        public async Task CheckUserExistsAsync(string userId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == userId);
            if (!userExists)
            {
                throw new CustomException("User not found!");
            }
        }

        public async Task CheckUserExistsAndEnabledAsync(string userId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == userId && u.IsEnabled);
            if (!userExists)
            {
                throw new CustomException("User not found!");
            }
        }

        public bool CheckPasswordMatchHash(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

        public async Task CheckEntityExistsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string errorMessage) where TEntity : class
        {
            var exists = await _context.Set<TEntity>().AnyAsync(predicate);
            if (!exists)
            {
                throw new CustomException(errorMessage);
            }
        }

        public async Task CheckEntityNotExistsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string errorMessage) where TEntity : class
        {
            var exists = await _context.Set<TEntity>().AnyAsync(predicate);
            if (exists)
            {
                throw new CustomException(errorMessage);
            }
        }

        public (bool exists, string suggestedUsername) CheckUsernameExists(string username)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                int counter = 0;
                string newUsername;
                do
                {
                    newUsername = $"{username}_{counter}";
                    counter++;
                } while (_context.Users.Any(u => u.Username == newUsername));

                return (true, newUsername);
            }
            return (false, username);
        }
    }
}
