namespace Domain.Shared.Validations
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error[] Errors { get; }

        protected Result(bool isSuccess, Error[] errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result SuccessResult() => new Result(true, null!);
        public static Result FailureResult(Error[] errors) => new Result(false, errors);
    }
}
