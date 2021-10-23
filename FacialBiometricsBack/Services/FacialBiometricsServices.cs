using FacialBiometrics.Models;
using FacialBiometricsBack.DataAccessFacialBiometrics;
using FacialBiometricsBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometricsBack.Services
{
    public class FacialBiometricsServices : IFacialBiometricsServices
    {
        private IDataAccessFacialBiometrics _dataAccess;

        public FacialBiometricsServices(IDataAccessFacialBiometrics dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int CreateUser(UserInfo userInfo)
        {
            try
            {
                if (userInfo == null) throw new ArgumentNullException(nameof(userInfo));

                return _dataAccess.CreateUser(userInfo);
            }
            catch
            {
                throw;
            }
        }

        public void CreateFacialBiometrics(UsersFacialBiometrics userImages)
        {
            try
            {
                if (userImages == null) throw new ArgumentNullException(nameof(userImages));

                _dataAccess.CreateFacialBiometrics(userImages);
            }
            catch
            {
                throw;
            }
        }


        public RuralPropertiesInfo GetRuralInfo(UserInfo userInfo)
        {
            try
            {
                if (userInfo == null) throw new ArgumentNullException(nameof(userInfo));

                return _dataAccess.GetRuralInfo(userInfo);
            }
            catch
            {
                throw;
            }
        }

        public int GetUserPosition(UserInfo userInfo)
        {
            try
            {
                if (userInfo == null) throw new ArgumentNullException(nameof(userInfo));

                return _dataAccess.GetUserPosition(userInfo);
            }
            catch
            {
                throw;
            }
        }

        public List<ArticleModel> GetArticles(int idUser){
            try{
                return _dataAccess.GetArticles(idUser);
            }catch{
                throw;
            }
        }

        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
