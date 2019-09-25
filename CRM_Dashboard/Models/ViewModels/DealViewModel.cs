using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models.ViewModels
{
    public class DealViewModel
    {
        public Deal Deal { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<FullName> EmployeesNames { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}