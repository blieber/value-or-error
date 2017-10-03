namespace ErrorFlow
{
    public interface IValueOrError<out TValue, out TError>
    {
        TValue value { get; }
        TError error { get; }
        bool hasValue { get; }
    }
}