using MediatR;
using PromomashTest.Application.DTO;
using PromomashTest.Application.Interfaces;
using PromomashTest.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Application.Handlers
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly ICountryRepository _repository;

        public GetCountriesQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _repository.GetAllAsync();

            return countries.Select(c => new CountryDto
            {
                Id = c.Id,
                Name = c.Name,
                Provinces = c.Provinces.Select(p => new ProvinceDto
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList()
            }).ToList();
        }
    }
}
