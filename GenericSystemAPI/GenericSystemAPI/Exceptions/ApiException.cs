using System;
using GenericSystemAPI.Models;

namespace GenericSystemAPI.Exceptions
{
    public class ApiException : Exception
    {
        public ErrorModel ApiError { get; }

        public ApiException(ErrorModel apiError) : base(apiError.error)
        {
            ApiError = apiError;
        }
    }
}