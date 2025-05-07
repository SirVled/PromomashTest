using Microsoft.EntityFrameworkCore;
using PromomashTest.Application.Interfaces;
using PromomashTest.Domain.Entities;
using PromomashTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            if (await EmailExistsAsync(user.Email)) throw new Exception("Email already exists");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
            if(await EmailExistsAsync(user.Email)) throw new Exception("Email already exists");
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
