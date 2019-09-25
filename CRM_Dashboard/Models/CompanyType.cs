using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class CompanyType
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<CompaniesType> CompaniesTypes { get; set; }
    }
}
