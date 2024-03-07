using System.ComponentModel.DataAnnotations;

namespace TestBackgroundService.Models
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
