using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class Employee
    {
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Job Title")]
        public long JobTitleId { get; set; }
        [ForeignKey(nameof(JobTitleId))]
        public JobTitle JobTitle { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name ="Country")]
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        [Display(Name ="City")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        public string Address { get; set; }

        [Display(Name ="Nationality 1")]
        public int Nationality1Id { get; set; }
        [ForeignKey(nameof(Nationality1Id))]
        public Nationality Nationality1 { get; set; }

        [Display(Name = "Nationality 2")]
        public int Nationality2Id { get; set; }
        [ForeignKey(nameof(Nationality2Id))]
        public Nationality Nationality2 { get; set; }

        public string Notes { get; set; }
    }
}
