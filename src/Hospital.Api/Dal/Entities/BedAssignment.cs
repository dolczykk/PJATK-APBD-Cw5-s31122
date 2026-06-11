namespace Hospital.Api.Dal.Entities;

public class BedAssignment
{
    public int Id { get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }

    public int BedId { get; set; }
    public virtual Bed Bed { get; set; } = null!;

    public string PatientPesel { get; set; } = null!;
    public virtual Patient PatientPeselNavigation { get; set; } = null!;
}