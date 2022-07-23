using Microsoft.AspNetCore.Mvc;

namespace CleanArchTemplate.Shared.Helpers
{
    public interface IProblemDetailsHelper
    {
        ProblemDetails GetGlobalProblemDetails();
    }
}