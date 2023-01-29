using FluentResults;
using Microsoft.AspNetCore.Mvc;
using PicturePortal.Contracts.Responses;

namespace PicturePortal.Helpers;

public static class ResultExtensions
{
    public static BadRequestObjectResult ToBadRequest(this Result result)
    {
        return new BadRequestObjectResult(
            new ErrorResponse
            {
                Errors = result.Errors.Select(e => e.Message)
            });
    }

    public static BadRequestObjectResult ToBadRequest<T>(this Result<T> result)
    {
        return new BadRequestObjectResult(
            new ErrorResponse
            {
                Errors = result.Errors.Select(e => e.Message)
            });
    }
}
