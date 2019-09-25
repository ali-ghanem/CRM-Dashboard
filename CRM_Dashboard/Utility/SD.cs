using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_Dashboard.Models;

namespace CRM_Dashboard.Utility
{
    public class SD
    {
        public const string DefaultImage = @"img\default_image.png";
        public const string CustomersDirectory = @"files\customers";
        public const string CompaniesDirectory = @"files\companies";
        public const string ProjectsDirectory = @"files\projects";
        public const string VisitsDirectory = @"files\visits";
        public const string DealsDirectory = @"files\deals";
        public const string DealPaymentsDirectory = @"files\dealPayments";


        internal static string OwnerDirectory(OwnerType ownerType)
        {
            switch (ownerType)
            {
                case OwnerType.Customers:
                    return CustomersDirectory;
                case OwnerType.Projects:
                    return ProjectsDirectory;
                case OwnerType.Companies:
                    return CompaniesDirectory;
                case OwnerType.Visits:
                    return VisitsDirectory;
                case OwnerType.Deals:
                    return DealsDirectory;
                case OwnerType.DealPayments:
                    return DealPaymentsDirectory;
                default:
                    return @"files";
            }
        }
    }
}
