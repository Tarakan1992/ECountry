using ECountry.Application.Features.Users.Queries;
using Hommy.ApiResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECountry.Web.Controllers
{
    public class UserControllercs : ApiControllerBase
    {
        private readonly ISender _sender;

        public UserControllercs(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("user")]
        public async Task<ApiResult> GetProperties()
        {
            return await _sender.Send(new GetUsersQuery());
        }
    }
}
