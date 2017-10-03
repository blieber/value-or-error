using System;

namespace ValueOrError.Core
{
    public partial struct ValueOrError<TValue, TError> : IEquatable<ValueOrError<TValue, TError>>
    {
        public bool Equals(ValueOrError<TValue, TError> other)
        {
            return (this.hasValue && other.hasValue && this.value.Equals(other.value)) ||
                   (!this.hasValue && !other.hasValue && this.error.Equals(other.error));
        }

        public override bool Equals(object other)
        {
            if (other is ValueOrError<TValue, TError>)
                return this.Equals((ValueOrError<TValue, TError>) other);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.hasValue ? value.GetHashCode() : error.GetHashCode();
        }

        public static bool operator ==(ValueOrError<TValue, TError> lhs, ValueOrError<TValue, TError> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ValueOrError<TValue, TError> lhs, ValueOrError<TValue, TError> rhs)
        {
            return !lhs.Equals(rhs);
        }
    }
}