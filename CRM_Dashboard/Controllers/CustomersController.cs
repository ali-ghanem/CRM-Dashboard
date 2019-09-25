using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM_Dashboard.Data;
using CRM_Dashboard.Models;
using CRM_Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Dashboard.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public CustomerViewModel CustomerViewModel { get; set; }

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
            CustomerViewModel = new CustomerViewModel()
            {
                Customer = new Customer(),
                JobTitles = _context.JobTitles.ToList(),
                Countries = _context.Countries.ToList(),
                Cities = _context.Cities.ToList(),
                Nationalities = _context.Nationalities.ToList()
            };
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public async Task<IActionResult> Get(long id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public async Task<IActionResult> Files(long id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Files", new { ownerType = OwnerType.Customers, ownerId = customer.Id });
        }

        public IActionResult Create()
        {
            return View(CustomerViewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreate()
        {
            if (!ModelState.IsValid)
            {
                return View(CustomerViewModel);
            }
            var customer = CustomerViewModel.Customer;
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            CustomerViewModel.Customer = customer;
            return View(CustomerViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEdit()
        {
            if (!ModelState.IsValid)
            {
                return View(CustomerViewModel);
            }
            var customer = CustomerViewModel.Customer;
            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == customer.Id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.JobTitleId = customer.JobTitleId;
            customerInDb.Gender = customer.Gender;
            customerInDb.CountryId = customer.CountryId;
            customerInDb.CityId = customer.CityId;
            customerInDb.Nationality1Id = customer.Nationality1Id;
            customerInDb.Nationality2Id = customer.Nationality2Id;
            customerInDb.Address = customer.Address;
            customerInDb.Notes = customer.Notes;

            await _context.SaveChangesAsync();
            return RedirectToAction("Get", new { id = customerInDb.Id });
        }


        public async Task<IActionResult> Delete(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}