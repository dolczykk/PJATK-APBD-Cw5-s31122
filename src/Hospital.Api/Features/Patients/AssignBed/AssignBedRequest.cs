using System.ComponentModel.DataAnnotations;

namespace Hospital.Api.Features.Patients.AssignBed;

public sealed record AssignBedRequest(
    DateTime From = default,
    DateTime? To = null,
    string BedType = "",
    string Ward = "") : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (From == default)
        {
            yield return new ValidationResult("Pole From jest wymagane", [nameof(From)]);
        }

        if (To.HasValue && To <= From)
        {
            yield return new ValidationResult("Pole To musi być późniejsze niż From", [nameof(To)]);
        }

        if (string.IsNullOrWhiteSpace(BedType))
        {
            yield return new ValidationResult("Pole BedType jest wymagane", [nameof(BedType)]);
        }

        if (string.IsNullOrWhiteSpace(Ward))
        {
            yield return new ValidationResult("Pole Ward jest wymagane", [nameof(Ward)]);
        }
    }
}
