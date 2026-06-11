namespace Hospital.Api.Dal.Entities;

public sealed class Admission
{
    public int Id { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }

    public string PatientPesel { get; set; } = null!;
    public Patient PatientPeselNavigation { get; set; } = null!;

    public int WardId { get; set; }
    public Ward Ward { get; set; } = null!;
}