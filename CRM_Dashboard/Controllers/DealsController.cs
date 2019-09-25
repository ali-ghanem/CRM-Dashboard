using CRM_Dashboard.Data;
using CRM_Dashboard.Models;
using CRM_Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Controllers
{
    public class DealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public DealViewModel DealViewModel { get; set; }

        public DealsController(ApplicationDbContext context)
        {
            _context = context;
            DealViewModel = new DealViewModel()
            {
                Deal = new Deal(),
                Employees = _context.Employees.ToList(),
                Products = _context.Products.ToList(),
                Projects = _context.Projects.ToList()
            };
            DealViewModel.EmployeesNames = DealViewModel.Employees.Select(c => new FullName() { Id = c.Id, Name = c.FirstName + " " + c.LastName });
        }

        public IActionResult Index()
        {
            var deals = _context.Deals.ToList();
            return View(deals);
        }

        public async Task<IActionResult> Get(long id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            return View(deal);
        }

        public async Task<IActionResult> Files(long id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if (deal == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Files", new { ownerType = OwnerType.Deals, ownerId = id });
        }

        public IActionResult Create()
        {
            return View(DealViewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreate()
        {
            if (!ModelState.IsValid)
            {
                return View(DealViewModel);
            }

            var deal = DealViewModel.Deal;
            await _context.Deals.AddAsync(deal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if(deal == null)
            {
                return NotFound();
            }
            DealViewModel.Deal = deal;
            return View(DealViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> PostEdit()
        {
            var deal = DealViewModel.Deal;
            if (!ModelState.IsValid)
            {
                return View(DealViewModel);
            }
            var dealInDb = await _context.Deals.FindAsync(deal.Id);
            dealInDb.DealName = deal.DealName;
            dealInDb.ProjectId = deal.ProjectId;
            dealInDb.EmployeeId = deal.EmployeeId;
            dealInDb.Ammount = deal.Ammount;
            dealInDb.Currency = deal.Currency;
            dealInDb.ProductId = deal.ProductId;
            dealInDb.CloseDate = deal.CloseDate;
            dealInDb.Notes = deal.Notes;
            dealInDb.TypePayment = deal.TypePayment;

            await _context.SaveChangesAsync();
            return RedirectToAction("Get", new { deal.Id });
        }

        public async Task<IActionResult> Delete(long id)
        {
            var deal = await _context.Deals.FindAsync(id);
            if(deal == null)
            {
                return NotFound();
            }
            _context.Deals.Remove(deal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
