using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models.ViewModels
{
    public class FileViewModel
    {
        public IEnumerable<File> Files { get; set; }
        public OwnerType OwnerType { get; set; }
        public long OwnerId { get; set; }

    }
}
