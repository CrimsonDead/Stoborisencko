using System.ComponentModel.DataAnnotations;

namespace datalayer.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Year { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}