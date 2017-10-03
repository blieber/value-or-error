using System;
using Xunit;
using ValueOrError.Core;
using ValueOrError.Linq;
using System.Threading.Tasks;

namespace ValueOrError.Linq.Async.Tests
{
    public class IValueOrErrorOnSuccessOnErrorAsyncTest
    {
        public class FromValue 
        {
            [Fact]
            public async Task OnSuccessAsync()
            {
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                var result = await valueOrError.OnSuccess(value => Task.Run(() => !value));
                Assert.NotEqual(valueOrError, result);
                Assert.Equal(!valueOrError.value, result.value);
            }

            [Fact]
            public async Task OnErrorAsync()
            {
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                var result = await valueOrError.OnError(error => Task.Run(() => !error));
                Assert.Equal(valueOrError, result);
            }

            [Fact]
            public async Task OnSuccessAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                await valueOrError.OnSuccess(value => Task.Run(() => { result = value; }));
                Assert.True(result);
            }

            [Fact]
            public async Task OnErrorAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                await valueOrError.OnError(error => Task.Run(() => { result = error; }));
                Assert.False(result);
            }
        }

        public class FromError 
        {
            [Fact]
            public async Task OnSuccess()
            {
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                var result = await valueOrError.OnSuccess(value => Task.Run(() => !value));
                Assert.Equal(valueOrError, result);
            }

            [Fact]
            public async Task OnError()
            {
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                var result = await valueOrError.OnError(error => Task.Run(() => !error));
                Assert.NotEqual(valueOrError, result);
                Assert.Equal(!valueOrError.error, result.error);
            }

            [Fact]
            public async Task OnSuccessAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                await valueOrError.OnSuccess(value => Task.Run(() => { result = value; }));
                Assert.False(result);
            }

            [Fact]
            public async Task OnErrorAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                await valueOrError.OnError(error => Task.Run(() => { result = error; }));
                Assert.True(result);
            }
        }
    }
}
