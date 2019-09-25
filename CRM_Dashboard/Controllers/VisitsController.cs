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
    public class VisitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public VisitViewModel VisitViewModel { get; set; }

        public VisitsController(ApplicationDbContext context)
        {
            _context = context;
            VisitViewModel = new VisitViewModel()
            {
                Visit = new Visit(),
                Countries = _context.Countries.ToList(),
                Cities = _context.Cities.ToList(),
                CompanyTypes = _context.CompanyTypes.ToList(),
                JobTitles = _context.JobTitles.ToList(),
                Employees = _context.Employees.ToList()
            };
            VisitViewModel.EmployeesNames = VisitViewModel.Employees.Select(c => new FullName() { Id = c.Id, Name = c.FirstName + " " + c.LastName });
        }

        public IActionResult Index()
        {
            var visits = _context.Visits.ToList();
            return View(visits);
        }

        public async Task<IActionResult> Get(long id)
        {
            var visit = await _context.Visits.FindAsync(id);
            return View(visit);
        }

        public async Task<IActionResult> Files(long id)
        {
            var visit = await _context.Visits.SingleOrDefaultAsync(c => c.Id == id);
            if (visit == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Files", new { ownerType = OwnerType.Visits, ownerId = visit.Id });
        }

        public IActionResult Create()
        {
            return View(VisitViewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreate()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var visit = VisitViewModel.Visit;

            await _context.Visits.AddAsync(visit);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var visit = await _context.Visits.SingleOrDefaultAsync(p => p.Id == id);
            if (visit == null)
            {
                return NotFound();
            }
            VisitViewModel.Visit = visit;
            return View(VisitViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEdit()
        {
            if (!ModelState.IsValid)
            {
                return View(VisitViewModel);
            }

            var visitInDb = await _context.Visits.SingleOrDefaultAsync(p => p.Id == VisitViewModel.Visit.Id);
            if (visitInDb == null)
            {
                return NotFound();
            }

            var visit = VisitViewModel.Visit;

            // update changes
            visitInDb.EmployeeId = visit.EmployeeId;
            visitInDb.CustomerName = visit.CustomerName;
            visitInDb.Mobile = visit.Mobile;
            visitInDb.Email = visit.Email;
            visitInDb.JobTitleId = visit.JobTitleId;
            visitInDb.Gender = visit.Gender;
            visitInDb.CountryId = visit.CountryId;
            visitInDb.CityId = visit.CityId;
            visitInDb.CompanyName = visit.CompanyName;
            visitInDb.CompanyMobile = visit.CompanyMobile;
            visitInDb.CompanyTypeId = visit.CompanyTypeId;
            visitInDb.Domain = visit.Domain;
            visitInDb.CompanyEmail = visit.CompanyEmail;
            visitInDb.Location = visit.Location;
            visitInDb.VisitRating = visit.VisitRating;
            visitInDb.VisitDate = visit.VisitDate;
            visitInDb.VisitTime = visit.VisitTime;
            visitInDb.Notes = visit.Notes;

            await _context.SaveChangesAsync();

            return RedirectToAction("Get", new { id = visit.Id });
        }

        public async Task<IActionResult> Delete(long id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}