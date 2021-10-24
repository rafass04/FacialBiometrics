using System.Collections.Generic;
using FacialBiometrics.Models;
using FacialBiometricsBack.Models;

namespace FacialBiometricsBack.DataAccessFacialBiometrics
{
    public interface IDataAccessFacialBiometrics
    {
        int CreateUser(UserInfo userInfo);

        void CreateFacialBiometrics(UsersFacialBiometrics userImages);

        int GetUserPosition(UserInfo userInfo);

        UserInfo GetUserByUsername(string username);

        RuralPropertiesInfo GetRuralInfo(UserInfo userInfo);
        List<ArticleModel> GetArticles(int idUser);
    }
}