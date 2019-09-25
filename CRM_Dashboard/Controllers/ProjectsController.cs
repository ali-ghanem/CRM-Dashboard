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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public ProjectViewModel ProjectViewModel { get; set; }

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
            ProjectViewModel = new ProjectViewModel()
            {
                Project = new Project(),
                Customers = _context.Customers.ToList(),
                ProjectTypes = _context.ProjectTypes.ToList()
            };
            ProjectViewModel.CustomersNames = ProjectViewModel.Customers.Select(c => new FullName() { Id = c.Id, Name = c.FirstName + " " + c.LastName });
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.Include(p => p.Customer).Include(p => p.ProjectsTypes).ToList();
            return View(projects);
        }

        public async Task<IActionResult> Get(long id)
        {
            var project = await _context.Projects.Include(p => p.ProjectsTypes).SingleOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        public async Task<IActionResult> Files(long id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(c => c.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Files", new { ownerType = OwnerType.Projects, ownerId = project.Id });
        }

        public IActionResult Create()
        {
            return View(ProjectViewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreate()
        {
            if (!ModelState.IsValid)
            {
                return View(ProjectViewModel);
            }
            var project = ProjectViewModel.Project;

            // get the selected types ids
            string typesList = "";
            typesList += ProjectViewModel.TypesList;
            if(typesList.Length > 0)
            {
                var projectTypesIds = typesList.Split(",");
                // Insert relations to ProjectsType table
                foreach (var id in projectTypesIds)
                {
                    var projectsType = new ProjectsType()
                    {
                        ProjectId = ProjectViewModel.Project.Id,
                        ProjectTypeId = long.Parse(id)
                    };
                    project.ProjectsTypes.Add(projectsType);
                }
            }

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(long id)
        {
            var project = await _context.Projects.Include(p => p.ProjectsTypes).SingleOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            ProjectViewModel.Project = project;
            return View(ProjectViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEdit()
        {
            if (!ModelState.IsValid)
            {
                return View(ProjectViewModel);
            }
            var project = ProjectViewModel.Project;

            var projectInDb = await _context.Projects.Include(p => p.ProjectsTypes).SingleOrDefaultAsync(p => p.Id == project.Id);
            if (projectInDb == null)
            {
                return NotFound();
            }

            // update changes
            projectInDb.Name = project.Name;
            projectInDb.CustomerId = project.CustomerId;

            // remove the old types 
            projectInDb.ProjectsTypes.Clear();

            // get the selected types ids
            string typesList = "";
            typesList += ProjectViewModel.TypesList;
            if(typesList.Length > 0)
            {
                var projectTypesIds = typesList.Split(",");
                // Insert relations to ProjectsType table
                foreach (var id in projectTypesIds)
                {
                    var projectsType = new ProjectsType()
                    {
                        ProjectId = ProjectViewModel.Project.Id,
                        ProjectTypeId = long.Parse(id)
                    };
                    projectInDb.ProjectsTypes.Add(projectsType);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Get", new { id = projectInDb.Id });
        }

        public async Task<IActionResult> Delete(long id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}