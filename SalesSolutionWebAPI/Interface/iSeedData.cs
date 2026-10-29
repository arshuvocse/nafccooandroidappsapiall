using System.Data;

namespace SalesSolutionWebAPI.Interface
{
    interface iSeedData
    {
        DataTable GetDivisions_All();
        DataTable GetDivisions_ByZoneId(int zoneId);



    }
}
