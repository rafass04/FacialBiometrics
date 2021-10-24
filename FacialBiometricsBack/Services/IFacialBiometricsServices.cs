using FacialBiometrics.Models;
using FacialBiometricsBack.Models;
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

        UserInfo Login(string userName, string password);

        List<ArticleModel> GetArticles(int idUser);
    }
}
