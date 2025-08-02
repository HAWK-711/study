using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresDataAccess.Models
{
    [Table("customers")]
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("email")]
        public string? Email { get; set; }
    }
}