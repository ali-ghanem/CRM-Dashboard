using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models.ViewModels
{
    public class VisitViewModel
    {

        public Visit Visit { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<JobTitle> JobTitles { get; set; }
        public IEnumerable<CompanyType> CompanyTypes { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<FullName> EmployeesNames { get; set; }

    }
}
