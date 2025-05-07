using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromomashTest.Application.DTO;
using PromomashTest.Application.Queries;

namespace PromomashTest.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvincesController : Controller
    {
        private readonly IMediator _mediator;

        public ProvincesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getProvinces")]
        public async Task<ActionResult<List<ProvinceDto>>> GetProvincesByCountryId(int countryId)
        {
            var provinces = await _mediator.Send(new GetProvincesByCountryIdQuery(countryId));
            return Ok(provinces);
        }
    }
}
