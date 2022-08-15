namespace Domain.Entities;

public class Customer:EntityBase,IEntityBase
{
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; } 
}
