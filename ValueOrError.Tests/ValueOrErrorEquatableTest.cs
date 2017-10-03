using System;
using Xunit;
using ValueOrError.Core;

namespace ValueOrError.Core.Tests
{
    public class ValueOrErrorEquatableTests
    {
        public class FromValue 
        {
            [Fact]
            public void Equals()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                var valueOrError2 = ValueOrError<bool, string>.FromValue(true);
                Assert.Equal(valueOrError, valueOrError2);
            }

            [Fact]
            public void NotEquals()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                var valueOrError2 = ValueOrError<bool, string>.FromValue(false);
                Assert.NotEqual(valueOrError, valueOrError2);
            }

            [Fact]
            public void ObjectEquals()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                var valueOrError2 = ValueOrError<bool, string>.FromValue(true);
                Assert.Equal((object) valueOrError, (object) valueOrError2);
            }

            [Fact]
            public void ObjectNotEquals()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                var valueOrError2 = ValueOrError<bool, string>.FromValue(false);
                Assert.NotEqual((object) valueOrError, (object) valueOrError2);
            }

            [Fact]
            public void EqualityOperatorsEquals()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                var valueOrError2 = ValueOrError<bool, string>.FromValue(true);
                Assert.True(valueOrError == valueOrError2);
                Assert.False(valueOrError != valueOrError2);
            }

            [Fact]
            public void EqualityOperatorsNotEquals()
            {
                var valueOrError = ValueOrError<bool, string>.FromValue(true);
                var valueOrError2 = ValueOrError<bool, string>.FromValue(false);
                Assert.False(valueOrError == valueOrError2);
                Assert.True(valueOrError != valueOrError2);
            }

            [Fact]
            public void GetHashCodeTest()
            {
                var value = "All the world's a stage, And all the men and women merely players";
                var valueOrError = ValueOrError<string, bool>.FromValue(value);
                Assert.Equal(value.GetHashCode(), valueOrError.GetHashCode());
            }
        }

        public class FromError 
        {
            [Fact]
            public void Equals()
            {
                var valueOrError = ValueOrError<string, bool>.FromError(true);
                var valueOrError2 = ValueOrError<string, bool>.FromError(true);
                Assert.Equal(valueOrError, valueOrError2);
            }

            [Fact]
            public void NotEquals()
            {
                var valueOrError = ValueOrError<string, bool>.FromError(true);
                var valueOrError2 = ValueOrError<string, bool>.FromError(false);
                Assert.NotEqual(valueOrError, valueOrError2);
            }

            [Fact]
            public void ObjectEquals()
            {
                var valueOrError = ValueOrError<string, bool>.FromError(true);
                var valueOrError2 = ValueOrError<string, bool>.FromError(true);
                Assert.Equal((object) valueOrError, (object) valueOrError2);
            }

            [Fact]
            public void ObjectNotEquals()
            {
                var valueOrError = ValueOrError<string, bool>.FromError(true);
                var valueOrError2 = ValueOrError<string, bool>.FromError(false);
                Assert.NotEqual((object) valueOrError, (object) valueOrError2);
            }

            [Fact]
            public void EqualityOperatorsEquals()
            {
                var valueOrError = ValueOrError<string, bool>.FromError(true);
                var valueOrError2 = ValueOrError<string, bool>.FromError(true);
                Assert.True(valueOrError == valueOrError2);
                Assert.False(valueOrError != valueOrError2);
            }

            [Fact]
            public void EqualityOperatorsNotEquals()
            {
                var valueOrError = ValueOrError<string, bool>.FromError(true);
                var valueOrError2 = ValueOrError<string, bool>.FromError(false);
                Assert.False(valueOrError == valueOrError2);
                Assert.True(valueOrError != valueOrError2);
            }

            [Fact]
            public void GetHashCodeTest()
            {
                var error = "They have their exits and their entrances, And one man in his time plays many parts";
                var valueOrError = ValueOrError<bool, string>.FromError(error);
                Assert.Equal(error.GetHashCode(), valueOrError.GetHashCode());
            }
        }
    }
}
