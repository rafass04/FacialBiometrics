using FacialBiometrics.Models;
using FacialBiometricsBack.Models;
using System.Collections.Generic;

namespace FacialBiometricsBack.Services
{
    public interface IFacialBiometricsServices
    {
        int CreateUser(UserInfo userInfo);

        void CreateFacialBiometrics(UsersFacialBiometrics userImages);

        int GetUserPosition(UserInfo userInfo);

        UserInfo Login(string userName, string password);

        List<ArticleModel> GetArticles(int idUser);

        List<string> GetUsersByLevel(int idPosition);

        public bool CompareImages(int idUser, List<byte[]> receivedImages);
    }
}