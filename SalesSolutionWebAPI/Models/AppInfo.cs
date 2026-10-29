using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesSolutionWebAPI.Models
{
    public class AppInfo
    {
        public int AppVersionId { get; set; }
        public int Version { get; set; }
        public string VersionName { get; set; }
        public bool IsActive { get; set; }
        public string DownloadUrl { get; set; }
        public bool IsForceUpdate { get; set; }
    }
}