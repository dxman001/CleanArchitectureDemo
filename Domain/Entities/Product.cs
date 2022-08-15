namespace Domain.Entities;

public class Product : EntityBase, IEntityBase
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

   
}