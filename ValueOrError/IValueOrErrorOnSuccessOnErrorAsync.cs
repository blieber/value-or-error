using System;
using System.Threading.Tasks;
using ValueOrError.Core;

namespace ValueOrError.Linq.Async
{
    public static class IValueOrErrorOnSuccessOnErrorAsync
    {
        public static async Task<ValueOrError<T, TError>> OnSuccess<TValue, TError, T>(
            this IValueOrError<TValue, TError> valueOrError, 
            Func<TValue, Task<T>> onSuccess)
        {
            if (valueOrError.hasValue)
            {
                var value = await onSuccess(valueOrError.value);
                return ValueOrError<T, TError>.FromValue(value);
            }
            else 
            {
                return ValueOrError<T, TError>.FromError(valueOrError.error);
            }
        }

        public static async Task<ValueOrError<TValue, T>> OnError<TValue, TError, T>(
            this IValueOrError<TValue, TError> valueOrError, 
            Func<TError, Task<T>> onError)
        {
            if (valueOrError.hasValue)
            {
                return ValueOrError<TValue, T>.FromValue(valueOrError.value);
            }
            else 
            {
                var error = await onError(valueOrError.error);
                return ValueOrError<TValue, T>.FromError(error);
            }
        }

        public static async Task OnSuccess<TValue, TError>(
            this IValueOrError<TValue, TError> valueOrError, 
            Func<TValue, Task> onSuccess)
        {
            if (valueOrError.hasValue)
            {
                await onSuccess(valueOrError.value);
            }
        }

        public static async Task OnError<TValue, TError>(
            this IValueOrError<TValue, TError> valueOrError, 
            Func<TError, Task> onError)
        {
            if (!valueOrError.hasValue)
            {
                await onError(valueOrError.error);
            }
        }
    }
}