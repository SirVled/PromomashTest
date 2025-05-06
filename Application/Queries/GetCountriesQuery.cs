using MediatR;
using PromomashTest.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Application.Queries
{
    public record GetCountriesQuery : IRequest<List<CountryDto>>;
}
