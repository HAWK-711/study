namespace PostgresDataAccess.Models
{
    public interface IOrder
    {
        int Id { get; set; }
        int UserId { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}