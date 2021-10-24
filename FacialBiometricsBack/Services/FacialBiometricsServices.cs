﻿using FacialBiometrics.Models;
using FacialBiometricsBack.DataAccessFacialBiometrics;
using FacialBiometricsBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

                userInfo.SaltPassword = CreateSalt(25);
                userInfo.Password = GenerateHash(userInfo.Password, userInfo.SaltPassword);

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
            try
            {
                if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password)) 
                    throw new ArgumentNullException("Username or password null");

                var result = _dataAccess.GetUserByUsername(userName);

                if (result == null)
                if (result == null)
                    return false;

                if (result.Password != GenerateHash(password, result.SaltPassword))
                    return false;

                return true;
            }
            catch
            {
                throw;
            }
        }

        private string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[size];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private string GenerateHash(string password, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);

            SHA256Managed sha256 = new SHA256Managed();

            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}