using FacialBiometrics.Models;

namespace FacialBiometricsBack.DataAccessFacialBiometrics
{
    public interface IDataAccessFacialBiometrics
    {
        void CreateUser(UserInfo userInfo);

        int GetUserPosition(UserInfo userInfo);

        bool Login(string userName, string password);

        RuralPropertiesInfo GetRuralInfo(UserInfo userInfo);
    }
}