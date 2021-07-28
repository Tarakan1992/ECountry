using ECountry.Application.Features.Fields.Commands;
using ECountry.Application.Features.Fields.Queries;
using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECountry.Web.Controllers
{

    public class FieldController : ApiControllerBase
    {
        private readonly ISender _sender;

        public FieldController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("field")]
        public async Task<ApiResult> GetFields()
        {
            return await _sender.Send(new GetFieldsQuery());
        }

        [HttpPost("field")]
        public async Task<ApiResult> CreateField([FromBody]CreateFieldCommand request)
        {
            return await _sender.Send(request);
        }
    }
}
