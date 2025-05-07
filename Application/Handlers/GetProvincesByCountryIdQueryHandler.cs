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
    public class GetProvincesByCountryIdQueryHandler : IRequestHandler<GetProvincesByCountryIdQuery, List<ProvinceDto>>
    {
        private readonly ICountryRepository _context;

        public GetProvincesByCountryIdQueryHandler(ICountryRepository context)
        {
            _context = context;
        }

        public async Task<List<ProvinceDto>> Handle(GetProvincesByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var provinces = await _context.GetProvinceByCountryIdAsync(request.CountryId);

            return provinces
                .Select(p => new ProvinceDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();
        }
    }
}
