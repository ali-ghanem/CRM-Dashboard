using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public partial class DealStage
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Deal")]
        public long DealId { get; set; }
        [ForeignKey("DealId")]
        public Deal Deal { get; set; }

        [Required]
        public DealStageEnum DealStageName { get; set; }

        public string Notes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StageDate { get; set; }
    }
}
