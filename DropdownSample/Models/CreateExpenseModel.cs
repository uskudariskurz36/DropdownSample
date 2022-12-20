using System.ComponentModel.DataAnnotations;

namespace DropdownSample.Models
{
    public class CreateExpenseModel
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string? Category { get; set; }

        public int UserId { get; set; }
    }
}
