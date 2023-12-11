namespace Domain.Shared.Validations
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        private ValidationResult(Error[] errors) : base(false, errors) => Errors = errors;

        public Error[] Errors { get; }

        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
}
