using FacialBiometrics.Models;

namespace FacialBiometricsBack.DataAccessFacialBiometrics
{
    public interface IDataAccessFacialBiometrics
    {
        int CreateUser(UserInfo userInfo);

        void CreateFacialBiometrics(UsersFacialBiometrics userImages);

        int GetUserPosition(UserInfo userInfo);

        bool Login(string userName, string password);

        RuralPropertiesInfo GetRuralInfo(UserInfo userInfo);
    }
}