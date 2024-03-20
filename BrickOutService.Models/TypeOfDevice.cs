using System.ComponentModel.DataAnnotations;

namespace BrickOutService.Models
{
    public class TypeOfDevice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
