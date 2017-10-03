using System;
using ValueOrError.Core;

namespace ValueOrError.Linq
{
    public static class OnSuccessOnErrorExtensions
    {
        public static ValueOrError<T, TError> OnSuccess<TValue, TError, T>(
            this ValueOrError<TValue, TError> valueOrError, 
            Func<TValue, T> onSuccess)
        {
            if (valueOrError.hasValue)
            {
                var value = onSuccess(valueOrError.value);
                return ValueOrError<T, TError>.FromValue(value);
            }
            else 
            {
                return ValueOrError<T, TError>.FromError(valueOrError.error);
            }
        }

        public static ValueOrError<TValue, T> OnError<TValue, TError, T>(
            this ValueOrError<TValue, TError> valueOrError, 
            Func<TError, T> onError)
        {
            if (valueOrError.hasValue)
            {
                return ValueOrError<TValue, T>.FromValue(valueOrError.value);
            }
            else 
            {
                var error = onError(valueOrError.error);
                return ValueOrError<TValue, T>.FromError(error);
            }
        }
    }
}