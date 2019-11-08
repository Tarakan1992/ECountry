﻿using IDS.Result.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;


namespace IDS.Result
{
    public class ApiResult : IActionResult
    {
        public Result Value { get; set; }

        public ApiResult(Result value)
        {
            Value = value;
        }

        public static implicit operator ApiResult(Result value)
        {
            return new ApiResult(value);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var result = new JsonResult(Value)
            {
                StatusCode = (int)(Value.Failure?.GetStatusCode() ?? HttpStatusCode.OK)
            };

            await result.ExecuteResultAsync(context);
        }
    }
}
