using System;
using Xunit;
using ValueOrError.Core;
using ValueOrError.Linq;

namespace ValueOrError.Linq.Tests
{
    public class IValueOrErrorOnSuccessOnErrorTest
    {
        public class FromValue 
        {
            [Fact]
            public void OnSuccess()
            {
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                var result = valueOrError.OnSuccess(value => !value);
                Assert.NotEqual(valueOrError, result);
                Assert.Equal(!valueOrError.value, result.value);
            }

            [Fact]
            public void OnError()
            {
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                var result = valueOrError.OnError(error => !error);
                Assert.Equal(valueOrError, result);
            }

            [Fact]
            public void OnSuccessAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                valueOrError.OnSuccess(value => { result = value; });
                Assert.True(result);
            }

            [Fact]
            public void OnErrorAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromValue(true);
                valueOrError.OnError(error => { result = error; });
                Assert.False(result);
            }
        }

        public class FromError 
        {
            [Fact]
            public void OnSuccess()
            {
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                var result = valueOrError.OnSuccess(value => !value);
                Assert.Equal(valueOrError, result);
            }

            [Fact]
            public void OnError()
            {
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                var result = valueOrError.OnError(error => !error);
                Assert.NotEqual(valueOrError, result);
                Assert.Equal(!valueOrError.error, result.error);
            }

            [Fact]
            public void OnSuccessAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                valueOrError.OnSuccess(value => { result = value; });
                Assert.False(result);
            }

            [Fact]
            public void OnErrorAction()
            {
                var result = false;
                var valueOrError = ValueOrError<bool, bool>.FromError(true);
                valueOrError.OnError(error => { result = error; });
                Assert.True(result);
            }
        }
    }
}
