namespace Hospital.Api.Dal.Entities;

public sealed class Room
{
    public string Id { get; set; } = null!;
    public bool HasTv { get; set; }

    public ICollection<Bed> Beds { get; set; } = new List<Bed>();

    public int WardId { get; set; }
    public Ward Ward { get; set; } = null!;
}