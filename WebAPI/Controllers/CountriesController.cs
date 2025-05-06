using MediatR;
using Microsoft.AspNetCore.Mvc;
using PromomashTest.Application.DTO;
using PromomashTest.Application.Queries;

namespace PromomashTest.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> Get()
        {
            var countries = await _mediator.Send(new GetCountriesQuery());
            return Ok(countries);
        }
    }
}
