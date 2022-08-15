namespace Domain.Entities;

public interface IEntityBase
{
    int Id { get; }
    DateTime? Created { get; set; }
    DateTime LastModified { get; set; }
}
