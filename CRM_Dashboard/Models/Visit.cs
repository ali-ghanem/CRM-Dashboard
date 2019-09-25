using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class Visit : IEntityHasFiles
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public long EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [Required]
        [Display( Name = "Customer Name")]
        public string CustomerName { get; set; }

        public int? Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public long JobTitleId { get; set; }
        [ForeignKey("JobTitleId")]
        public JobTitle JobTitle { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Mobile")]
        public int CompanyMobile { get; set; }

        [Required]
        [Display(Name = "Company Type")]
        public long CompanyTypeId { get; set; }
        [ForeignKey("CompanyTypeId")]
        public CompanyType CompanyType { get; set; }

        public string Domain { get; set; }

        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }

        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; }

        [Required]
        [Display(Name = "Visit Time")]
        public decimal VisitTime { get; set; }

        public string Notes { get; set; }

        public ICollection<VisitService> VisitServices { get; set; }

        [Display(Name = "Visit Rate")]
        public VisitRatingEnum VisitRating { get; set; }

        public ICollection<File> Files { get; set; }

        public Visit()
        {
            Files = new HashSet<File>();
        }
    }
}
