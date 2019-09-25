using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM_Dashboard.Data;
using CRM_Dashboard.Models;
using CRM_Dashboard.Models.ViewModels;
using CRM_Dashboard.Utility;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Dashboard.Controllers
{
    public class FilesController : Controller
    {
        private readonly HostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public FileViewModel FileViewModel { get; set; }

        public FilesController(ApplicationDbContext context, HostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            FileViewModel = new FileViewModel() { };
        }

        public IActionResult Index(OwnerType ownerType, long ownerId)
        {
            FileViewModel.Files = _context.Files.Where(f => f.OwnerType == ownerType && f.OwnerId == ownerId).ToList();
            FileViewModel.OwnerId = ownerId;
            FileViewModel.OwnerType = ownerType;
            return View(FileViewModel);
        }

        public async Task<IActionResult> AddFiles()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var ownerId = FileViewModel.OwnerId;
            var ownerType = FileViewModel.OwnerType;

            if (files.Count != 0)
            {
                IEntityHasFiles entity = null;
                switch (ownerType)
                {
                    case OwnerType.Customers:
                        entity = await _context.Customers.FindAsync(ownerId);
                        break;
                    case OwnerType.Projects:
                        entity = await _context.Projects.FindAsync(ownerId);
                        break;
                    case OwnerType.Companies:
                        entity = await _context.Companies.FindAsync(ownerId);
                        break;
                    case OwnerType.Visits:
                        entity = await _context.Visits.FindAsync(ownerId);
                        break;
                    case OwnerType.Deals:
                        entity = await _context.Deals.FindAsync(ownerId);
                        break;
                    case OwnerType.DealPayments:
                        entity = await _context.DealPayments.FindAsync(ownerId);
                        break;
                    default:
                        break;
                }

                string uploads = Path.Combine(webRootPath, SD.OwnerDirectory(ownerType));
                foreach (var file in files)
                {
                    var extension = Path.GetExtension(file.FileName);
                    var dbFile = new Models.File()
                    {
                        Name = file.Name,
                        FileExtension = extension,
                        FileName = file.FileName,
                        OwnerId = entity.Id,
                        OwnerType = FileViewModel.OwnerType
                    };
                    using (var filestream = new FileStream(Path.Combine(uploads, entity.Id + "_" + file.FileName), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    dbFile.FilePath = @"\" + SD.OwnerDirectory(ownerType) + @"\" + entity.Id + "_" + file.FileName;

                    entity.Files.Add(dbFile);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { ownerType, ownerId });
        }


        public async Task<IActionResult> Delete(long id, string filePath, OwnerType ownerType, long ownerId)
        {
            var file = await _context.Files.FindAsync(id);
            _context.Files.Remove(file);

            string webRootPath = _hostingEnvironment.WebRootPath;
            System.IO.File.Delete(webRootPath + filePath);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { ownerType, ownerId });
        }
    }
}