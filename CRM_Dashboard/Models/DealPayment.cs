using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class DealPayment : IEntityHasFiles
    {
        public long Id { get; set; }

        [Required]
        public long DealId { get; set; }
        [ForeignKey("DealId")]
        public Deal Deal { get; set; }

        [Required]
        public decimal Payment { get; set; }

        public CurrencyEnum Currency { get; set; }

        public decimal PriceExchange { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NextPaymentDate { get; set; }

        public ICollection<File> Files { get; set; }

        public DealPayment()
        {
            Files = new HashSet<File>();
        }

    }
}
