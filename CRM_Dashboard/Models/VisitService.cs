using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Dashboard.Models
{
    public class VisitService
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Visit")]
        public long VisitId { get; set; }
        [ForeignKey("VistId")]
        public Visit Visit { get; set; }

        [Display(Name = "Service")]
        public long ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}