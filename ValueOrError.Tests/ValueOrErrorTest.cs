using System;
using Xunit;
using ValueOrError.Core;

namespace ValueOrError.Core.Tests
{
    public class ValueOrErrorTests
    {
        public class FromValue 
        {
            [Fact]
            public void Value()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                Assert.True(valueOrError.value);
            }

            [Fact]
            public void Error()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                Assert.Throws<InvalidOperationException>(() => valueOrError.error);
            }

            [Fact]
            public void HasValue()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                Assert.True(valueOrError.hasValue);
            }
        }

        public class FromError 
        {
            [Fact]
            public void Value()
            {
                var valueOrError = ValueOrError<bool, string>.FromError("I'm an error");
                Assert.Throws<InvalidOperationException>(() => valueOrError.value);
            }

            [Fact]
            public void Error()
            {
                var valueOrError = ValueOrError<bool, string>.FromError("I'm an error");
                Assert.Equal("I'm an error", valueOrError.error);
            }

            [Fact]
            public void HasValue()
            {
                var valueOrError = ValueOrError<bool, string>.FromError("I'm an error");
                Assert.False(valueOrError.hasValue);
            }
        }
    }
}
