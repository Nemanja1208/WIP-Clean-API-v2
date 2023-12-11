namespace Domain.Shared.Validations
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new("ValidationError", "A validation problem has occured.");
        Error[] Errors { get; }
    }
}
