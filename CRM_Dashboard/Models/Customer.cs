using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class Customer : IEntityHasFiles
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Job Title")]
        public long JobTitleId { get; set; }
        [ForeignKey("JobTitleId")]
        public JobTitle JobTitle { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public string Address { get; set; }

        [Display(Name = "Nationality 1")]
        public int? Nationality1Id { get; set; }
        [ForeignKey("Nationality1Id")]
        public Nationality Nationality1 { get; set; }

        [Display(Name = "Nationality 2")]
        public int? Nationality2Id { get; set; }
        [ForeignKey("Nationality2Id")]
        public Nationality Nationality2 { get; set; }

        public string Notes { get; set; }

        public ICollection<File> Files { get; set; }

        public Customer()
        {
            Files = new HashSet<File>();
        }
    }
}
