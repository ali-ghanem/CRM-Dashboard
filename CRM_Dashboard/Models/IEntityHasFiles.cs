using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Dashboard.Models
{
    public interface IEntityHasFiles
    {
        long Id { get; set; }
        ICollection<File> Files { get; set; }
    }
}
