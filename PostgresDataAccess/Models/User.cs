using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresDataAccess.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}