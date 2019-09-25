using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public partial class Deal : IEntityHasFiles
    {
        public long Id { get; set; }
        
        [Required]
        [Display(Name = "Deal Name")]
        public string DealName { get; set; }

        [Display(Name = "Project")]
        public long ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public long EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [Required]
        public Decimal Ammount { get; set; }

        [Required]
        public CurrencyEnum Currency { get; set; }

        [Display(Name = "Product")]
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Close Date")]
        public DateTime CloseDate { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Payment Type")]
        public TypePaymentEnum TypePayment { get; set; }

        public ICollection<File> Files { get; set; }

        public Deal()
        {
            Files = new HashSet<File>();
        }
    }
}
