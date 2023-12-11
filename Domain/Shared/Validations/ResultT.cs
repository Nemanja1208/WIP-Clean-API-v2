namespace Domain.Shared.Validations
{
    public class Result<TValue>
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;
        public TValue Value { get; }
        public Error[] Errors { get; }

        protected Result(TValue value, bool isSuccess, Error[] errors)
        {
            Value = value;
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result<TValue> Fail(Error[] errors)
        {
            return new Result<TValue>(default!, false, errors);
        }

        public static Result<TValue> Ok(TValue value)
        {
            return new Result<TValue>(value, true, null!);
        }
    }
}
