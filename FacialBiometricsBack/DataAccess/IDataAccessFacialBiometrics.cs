using FacialBiometrics.Models;
using FacialBiometricsBack.Models;
using System.Collections.Generic;

namespace FacialBiometricsBack.DataAccessFacialBiometrics
{
    public interface IDataAccessFacialBiometrics
    {
        int CreateUser(UserInfo userInfo);

        void CreateFacialBiometrics(UsersFacialBiometrics userImages);

        int GetUserPosition(UserInfo userInfo);

        UserInfo GetUserByUsername(string username);

        List<ArticleModel> GetArticles(int idUser);

        List<string> GetUserByLevel(int idPosition);

        public List<UsersFacialBiometrics> GetFacialBiometric(int idUser);
    }
}