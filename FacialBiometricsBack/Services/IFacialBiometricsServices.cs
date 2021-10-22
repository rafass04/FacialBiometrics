using FacialBiometrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometricsBack.Services
{
    public interface IFacialBiometricsServices
    {
        int CreateUser(UserInfo userInfo);

        void CreateFacialBiometrics(UsersFacialBiometrics userImages);

        int GetUserPosition(UserInfo userInfo);

        bool Login(string userName, string password);

        RuralPropertiesInfo GetRuralInfo(UserInfo userInfo);
    }
}
