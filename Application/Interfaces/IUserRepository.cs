using PromomashTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task AddUserAsync(User user, CancellationToken cancellationToken);
        Task<bool> EmailExistsAsync(string email);
    }
}
