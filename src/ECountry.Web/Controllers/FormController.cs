using ECountry.Application.Features.Forms.Commands;
using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECountry.Web.Controllers
{
    public class FormController : ApiControllerBase
    {
        private readonly ISender _sender;

        public FormController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("form")]
        public async Task<ApiResult> CreateForm([FromBody]CreateFormCommand command)
        {
            return await _sender.Send(command);
        }
    }
}
