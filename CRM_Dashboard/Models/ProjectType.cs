using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class ProjectType
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<ProjectsType> ProjectsTypes { get; set; }
    }
}
