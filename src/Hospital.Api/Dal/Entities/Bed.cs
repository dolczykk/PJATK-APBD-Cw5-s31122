namespace Hospital.Api.Dal.Entities;

public sealed class Bed
{
    public int Id { get; set; }
    
    public BedType BedType { get; set; } = null!;
    public int BedTypeId { get; set; }
    
    public string RoomId { get; set; } = null!;
    public Room Room { get; set; } = null!;
    
    public ICollection<BedAssignment> BedAssignments { get; set; } = new List<BedAssignment>();
}
