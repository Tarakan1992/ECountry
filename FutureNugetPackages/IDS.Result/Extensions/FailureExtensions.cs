using System.Net;

namespace IDS.Result.Extensions
{
    public static class FailureExtensions
    {
        public static HttpStatusCode GetStatusCode(this Failure failure) => failure switch
        {
            ExceptionFailure _  => HttpStatusCode.InternalServerError,
            UnauthorizedFailure _ => HttpStatusCode.Unauthorized,
            ForbiddenFailure _ => HttpStatusCode.Forbidden,
            NotFoundFailure _ => HttpStatusCode.NotFound,
            _ => HttpStatusCode.BadRequest
        };
    }
}
