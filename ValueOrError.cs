namespace ValueOrError
{
    public class ValueOrError<TValue, TError> : IValueOrError<TValue, TError>
    {
        private readonly IValueOrError<TValue, TError> valueOrError;

        private ValueOrError(IValueOrError<TValue, TError> valueOrError)
        {
            this.valueOrError = valueOrError;
        }

        public static ValueOrError<TValue, TError> FromValue(TValue value)
        {
            return ValueOrError(ValueOrError_Value(value));
        }

        public static ValueOrError<TValue, TError> FromError(TError error)
        {
            return ValueOrError(ValueOrError_Error(error));
        }

        public TValue value => valueOrError.value;

        public TError error => valueOrError.error;

        public bool hasValue => valueOrError.hasValue;

        private class ValueOrError_Value : IValueOrError<TValue, TError>
        {
            public ValueOrError_Value(TValue value)
            {
                this.value = value;
            }

            public TValue value { get; }

            public TError error 
            {
                get
                {
                    throw new InvalidOperationException("Error cannot be accessed on Value type container.");
                }
            }

            public bool hasValue => true;
        }

        private class ValueOrError_Error : IValueOrError<TValue, TError>
        {
            public ValueOrError_Error(TError error)
            {
                this.error = error;
            }

            public TValue value
            {
                get
                {
                    throw new InvalidOperationException("Value cannot be accessed on Error type container.");
                }
            }

            public TError error { get; }

            public bool hasValue => false;
        }
    }
}