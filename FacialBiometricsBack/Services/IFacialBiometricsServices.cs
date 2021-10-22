using FacialBiometrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometricsBack.Services
{
    public interface IFacialBiometricsServices
    {
        void CreateUser(UserInfo userInfo);

        int GetUserPosition(UserInfo userInfo);

        bool Login(string userName, string password);

        RuralPropertiesInfo GetRuralInfo(UserInfo userInfo);
    }
}
