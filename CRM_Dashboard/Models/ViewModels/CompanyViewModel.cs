using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models.ViewModels
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<FullName> CustomersNames { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<CompanyType> CompanyTypes { get; set; }
        public IEnumerable<CompaniesType> CompaniesTypes { get; set; }
        public IFormFile Files { get; set; }
        public string TypesList { get; set; }
    }
}
