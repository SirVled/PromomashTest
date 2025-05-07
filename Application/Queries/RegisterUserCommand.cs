using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Application.Queries
{
    public record RegisterUserCommand(
     string Email,
     string Password,
     int CountryId,
     int ProvinceId
 ) : IRequest<int>;
}
