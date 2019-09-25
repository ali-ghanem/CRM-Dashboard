using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class Company : IEntityHasFiles
    {
        public long Id { get; set; }

        [Display(Name ="Customer")]
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Mobile { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public string Address { get; set; }

        [Display(Name="Division Number")]
        public int? DivisionNumber { get; set; }

        [Required]
        public string Location { get; set; }

        public string Notes { get; set; }

        public ICollection<CompaniesType> CompaniesTypes { get; set; }

        public ICollection<File> Files { get; set; }

        public Company()
        {
            CompaniesTypes = new List<CompaniesType>();
            Files = new HashSet<File>();
        }
    }
}
