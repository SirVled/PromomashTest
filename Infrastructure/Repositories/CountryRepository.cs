using MediatR;
using Microsoft.EntityFrameworkCore;
using PromomashTest.Application.DTO;
using PromomashTest.Application.Interfaces;
using PromomashTest.Domain.Entities;
using PromomashTest.Infrastructure.Data;
using System.Threading;


namespace PromomashTest.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries
             //   .Include(c => c.Provinces)
                .ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries
                .Include(c => c.Provinces)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Province>> GetProvinceByCountryIdAsync(int countryId)
        {
            return await _context.Provinces
                .Where(p => p.CountryId == countryId)
                .ToListAsync();
        }
    }
}
