using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Dashboard.Data;
using CRM_Dashboard.Models;
using CRM_Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Dashboard.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public CompanyViewModel CompanyViewModel { get; set; }

        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
            CompanyViewModel = new CompanyViewModel()
            {
                Company = new Company(),
                Customers = _context.Customers.ToList(),
                Countries = _context.Countries.ToList(),
                Cities = _context.Cities.ToList(),
                CompanyTypes = _context.CompanyTypes.ToList(),
                CompaniesTypes = _context.CompaniesTypes.ToList()
            };
            CompanyViewModel.CustomersNames = CompanyViewModel.Customers.Select(c => new FullName() { Id = c.Id, Name = c.FirstName + " " + c.LastName });
        }

        public IActionResult Index()
        {
            var companies = _context.Companies.Include(c => c.Customer).Include(c => c.CompaniesTypes).ToList();
            return View(companies);
        }

        public async Task<IActionResult> Get(long id)
        {
            var company = await _context.Companies.Include(c => c.CompaniesTypes).SingleOrDefaultAsync(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        public async Task<IActionResult> Files(long id)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Files", new { ownerType = OwnerType.Companies, ownerId = company.Id });
        }

        public IActionResult Create()
        {
            return View(CompanyViewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreate()
        {
            var company = CompanyViewModel.Company;

            if (!ModelState.IsValid)
            {
                return View(CompanyViewModel);
            }

            // Add company to database
            await _context.Companies.AddAsync(company);

            // get the selected types ids
            string typesList = "";
            typesList += CompanyViewModel.TypesList;
            if(typesList.Length > 0)
            {
                var companyTypesIds = typesList.Split(",");

                // Insert relations to CompaniesTypes table
                foreach (var id in companyTypesIds)
                {
                    var companyType = new CompaniesType()
                    {
                        CompanyId = company.Id,
                        CompanyTypeId = long.Parse(id)
                    };
                    await _context.CompaniesTypes.AddAsync(companyType);
                }
            }

            // Save Changes
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var company = await _context.Companies.Include(c => c.CompaniesTypes).SingleOrDefaultAsync(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            CompanyViewModel.Company = company;
            return View(CompanyViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEdit()
        {
            if (!ModelState.IsValid)
            {
                return View(CompanyViewModel);
            }
            var company = CompanyViewModel.Company;

            var companyInDb = await _context.Companies.FindAsync(company.Id);
            if (companyInDb == null)
            {
                return NotFound();
            }

            // update changes
            companyInDb.CustomerId = company.CustomerId;
            companyInDb.Name = company.Name;
            companyInDb.Email = company.Email;
            companyInDb.Mobile = company.Mobile;
            companyInDb.CountryId = company.CountryId;
            companyInDb.CityId = company.CityId;
            companyInDb.Address = company.Address;
            companyInDb.DivisionNumber = company.DivisionNumber;
            companyInDb.Location = company.Location;
            companyInDb.Notes = company.Notes;

            // remove the old types ids 
            companyInDb.CompaniesTypes.Clear();

            // get the selected types ids
            string typesList = "";
            typesList += CompanyViewModel.TypesList;
            if (typesList.Length > 0)
            {
                var companyTypesIds = typesList.Split(",");
                foreach (var id in companyTypesIds)
                {
                    var companiesType = new CompaniesType()
                    {
                        CompanyId = company.Id,
                        CompanyTypeId = long.Parse(id)
                    };
                    companyInDb.CompaniesTypes.Add(companiesType);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Get", new { id = companyInDb.Id });
        }

        public async Task<IActionResult> Delete(long id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
