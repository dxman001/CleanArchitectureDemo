namespace Application.Customers;
using Domain.Entities;

public class CustomerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Gender { get; set; }
}

public static class MapCustomer
{
    public static Customer MapToEntity(this CustomerModel customerModel, Customer? customer = null)
    {
        customer ??= new Customer();
        customer.Name = string.IsNullOrWhiteSpace(customerModel.Name)? customer.Name: customerModel.Name;
        customer.BirthDate = customerModel.BirthDate ?? customer.BirthDate;
        customer.Gender = customerModel.Gender==null? customer.Gender : customerModel.Gender.ToGenderEnum();
        customer.Created ??= DateTime.Now;
        customer.LastModified = DateTime.Now;
        return customer;
    }
    public static CustomerModel MapToModel(this Customer customer) =>
        new CustomerModel
        {
            Id = customer.Id,
            Name = customer.Name,
            BirthDate = customer.BirthDate,
            Gender = customer.Gender.ToGenderString()
        };
    

    private static Gender ToGenderEnum(this string gender) =>
        gender.ToLower() switch
        {
            "male" => Gender.Male,
            "female" => Gender.Female,
            "other" => Gender.Other,
            _ => throw new ArgumentOutOfRangeException(nameof(gender), $"Not expected Gender value: {gender}"),

        };


    private static string ToGenderString(this Gender gender) =>
        gender switch
        {
            Gender.Male => "Male",
            Gender.Female => "Female",
            Gender.Other => "Other",
            _ => throw new ArgumentOutOfRangeException(nameof(gender), $"Not expected Gender value: {gender}"),

        };
}