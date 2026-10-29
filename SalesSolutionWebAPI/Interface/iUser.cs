using SalesSolutionWebAPI.Models;

namespace SalesSolutionWebAPI.Interface
{
    interface iUser
    {
        User doLogin(string UserName, string password, string Imei, string DeviceToken, string Device, string AppVersion, string OS, string OS_Versio);

        void AddUser(User aUser);
        void RemoveUser(string userId);

        ResultInfo SaveTracking(UserTracking tracking);
    }
}
