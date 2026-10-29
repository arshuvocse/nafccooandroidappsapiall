using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesSolutionWebAPI.Models;

namespace SalesSolutionWebAPI.Interface
{
    public interface iFieldForceMarket
    {
        DataTable GetFieldForceMarket(string empId, string emprole);
        DataTable GetFieldForceSubTerritory(string empId, string emprole);
        DataTable GetFieldForceTerritory(string empId, string emprole);
        DataTable GetFieldForceArea(string empId, string emprole);
        DataTable GetFieldForceRegion(string empId, string emprole);
        DataTable GetFieldForceGroup(string empId, string emprole);
        DataTable GetFieldForceMio(string empId, string emprole);
        
        DataTable GetFieldForceAsm(string empId, string emprole);
        DataTable GetFieldForceRsm(string empId, string emprole);
        DataTable GetFieldForceNsm(string empId, string emprole);
    }
}
