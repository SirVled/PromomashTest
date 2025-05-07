using MediatR;
using PromomashTest.Application.Interfaces;
using PromomashTest.Application.Queries;
using PromomashTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Application.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository, ICountryRepository countryRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.CountryId);
            var province = country?.Provinces.FirstOrDefault(x => x.Id == request.ProvinceId);

            if (country == null || province == null)
                throw new Exception("Invalid country or province");

            #region Not best practic

            using var sha = SHA256.Create();
            var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
            string hashedPassword = Convert.ToBase64String(hashBytes);

            #endregion
            var user = new User
            {
                Email = request.Email,
                PasswordHash = hashedPassword,
                Country = country,
                Province = province,
            };

            await _userRepository.AddUserAsync(user, cancellationToken);

            return user.Id;
        }
    }
}
