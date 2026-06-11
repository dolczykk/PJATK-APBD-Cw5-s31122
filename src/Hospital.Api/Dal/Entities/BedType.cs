namespace Hospital.Api.Dal.Entities;

public sealed class BedType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Bed> Beds { get; set; } = new List<Bed>();
}