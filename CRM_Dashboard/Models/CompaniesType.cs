using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Dashboard.Models
{
    public class CompaniesType
    {
        [Key]
        public long Id { get; set; }

        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public long CompanyTypeId { get; set; }
        [ForeignKey("CompanyTypeId")]
        public CompanyType CompanyType { get; set; }
    }
}