using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class Project : IEntityHasFiles
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Customer")]
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Display(Name="Types")]
        public virtual ICollection<ProjectsType> ProjectsTypes { get; set; }
        public ICollection<File> Files { get; set; }

        public Project()
        {
            ProjectsTypes = new HashSet<ProjectsType>();
            Files = new HashSet<File>();
        }
    }
}
