using MediatR;
using PromomashTest.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Application.Queries
{
    public class GetProvincesByCountryIdQuery : IRequest<List<ProvinceDto>>
    {
        public int CountryId { get; set; }

        public GetProvincesByCountryIdQuery(int countryId)
        {
            CountryId = countryId;
        }
    }
}
