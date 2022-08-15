namespace Domain.Entities;

public class Employee : EntityBase, IEntityBase
{
    public string Name { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = string.Empty;
}
