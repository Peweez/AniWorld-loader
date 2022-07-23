using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CleanArchTemplate.Shared.Helpers
{
    public class ProblemDetailsHelper : IProblemDetailsHelper
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        public ProblemDetailsHelper(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        public ProblemDetails GetGlobalProblemDetails()
        {
            return new ProblemDetails { Type = _localizer["SomethingWentWrongType"], Title = _localizer["SomethingWentWrongTitle"], Detail = _localizer["SomethingWentWrongMessage"], Status = StatusCodes.Status500InternalServerError };
        }
    }
}
