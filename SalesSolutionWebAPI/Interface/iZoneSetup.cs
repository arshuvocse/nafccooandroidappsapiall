using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesSolutionWebAPI.Models;

namespace SalesSolutionWebAPI.Interface
{
    interface iZoneSetup
    {

        ResultInfo SaveZoneInfo(Zone zone);
        DataTable GetZoneList();
        ResultInfo UpdateActiveStatus(int zoneId,DateTime acDate,string reason,string loginUser, bool isActive);
        ResultInfo UpdateZoneInfo(Zone zone);


    }
}
