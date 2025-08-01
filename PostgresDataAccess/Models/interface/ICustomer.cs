namespace PostgresDataAccess.Models
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }
}