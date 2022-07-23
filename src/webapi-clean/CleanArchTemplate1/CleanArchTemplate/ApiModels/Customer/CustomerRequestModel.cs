namespace CleanArchTemplate.ApiModels.Customer;

public class CustomerRequestModel
{
    /// <example>John</example>
    public string FirstName { get; set; }
    /// <example>Wick</example>
    public string LastName { get; set; }
    /// <example>30</example>
    public int Age { get; set; }
    /// <example>John Wick's address</example>
    public string Address { get; set; }
}