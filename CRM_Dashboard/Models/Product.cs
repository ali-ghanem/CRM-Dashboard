using System.ComponentModel.DataAnnotations;

namespace CRM_Dashboard.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}