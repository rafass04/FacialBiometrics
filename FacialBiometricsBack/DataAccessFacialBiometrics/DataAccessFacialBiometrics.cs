using FacialBiometrics.Models;
using System;

namespace FacialBiometricsBack.DataAccessFacialBiometrics
{
    public class DataAccessFacialBiometrics : IDataAccessFacialBiometrics
    {
        private string ConnectionString = ""
        public void CreateUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public RuralPropertiesInfo GetRuralInfo(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int GetUserPosition(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}