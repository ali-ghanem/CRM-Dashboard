using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<FullName> CustomersNames { get; set; }
        public IEnumerable<ProjectType> ProjectTypes { get; set; }
        public IEnumerable<ProjectsType> ProjectsTypes { get; set; }
        public IFormFile Files { get; set; }
        public string TypesList { get; set; }
    }
}
