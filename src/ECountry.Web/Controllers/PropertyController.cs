using ECountry.Application.Features.Fields.Commands;
using ECountry.Application.Features.Fields.Queries;
using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECountry.Web.Controllers
{

    public class PropertyController : ApiControllerBase
    {
        private readonly ISender _sender;

        public PropertyController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("property")]
        public async Task<ApiResult> GetProperties()
        {
            return await _sender.Send(new GetPropertiesQuery());
        }

        [HttpPost("property")]
        public async Task<ApiResult> CreateProperty([FromBody]CreatePropertyCommand request)
        {
            return await _sender.Send(request);
        }
    }
}
