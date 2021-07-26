using ECountry.Application.Features.App.Queries;
using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECountry.Web.Controllers
{
    public class AppController : ApiControllerBase
    {
        private readonly ISender _sender;

        public AppController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("ping")]
        public async Task<ApiResult> Ping()
        {
            return await _sender.Send(new PingQuery());
        }
    }
}
