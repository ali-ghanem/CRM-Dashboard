using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public class ProjectsType
    {
        [Key]
        public long Id { get; set; }

        public long ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public long ProjectTypeId { get; set; }
        [ForeignKey("ProjectTypeId")]
        public ProjectType ProjectType { get; set; }
    }
}
