namespace Domain.Shared.Validations
{
    public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {

        private ValidationResult(Error[] errors) : base(default!, false, errors) => Errors = errors;

        public Error[] Errors { get; }

        public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
    }
}
