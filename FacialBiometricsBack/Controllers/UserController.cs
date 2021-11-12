using FacialBiometrics.Models;
using FacialBiometricsBack.Models;
using FacialBiometricsBack.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FacialBiometricsBack.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : Controller
    {
        private IFacialBiometricsServices _facialBiometricsService;

        public UserController(IFacialBiometricsServices facialBiometricsServices)
        {
            _facialBiometricsService = facialBiometricsServices;
        }

        [HttpPost("register")]
        public JsonResult UserRegistration(UserFrontModel userData)
        {
            if (ModelState.IsValid)
            {
                if (userData.face_images.Count() == 0)
                {
                    return Json(new { message = "No user image received.", statusCode = HttpStatusCode.BadRequest });
                }

                List<UserFaceImg> imageData = new List<UserFaceImg>();

                foreach (var img in userData.face_images)
                {
                    string[] imgData = img.Split(',');

                    imageData.Add(new UserFaceImg
                    {
                        metaData = imgData[0],
                        extension = imgData[0].Split(';')[0].Split('/')[1],
                        imageBytes = Convert.FromBase64String(imgData[1])
                    });
                }

                int idUser = _facialBiometricsService.CreateUser(new UserInfo
                {
                    NameUser = userData.name,
                    Username = userData.username,
                    Password = userData.password,
                    UserPositionInfo = new UserPosition { IdUserPosition = userData.id_user_position }
                });

                foreach (var faceImg in imageData)
                {
                    _facialBiometricsService.CreateFacialBiometrics(new UsersFacialBiometrics
                    {
                        ImageName = Guid.NewGuid().ToString(),
                        ImageBytes = faceImg.imageBytes,
                        IdUser = idUser
                    });
                }

                return Json(new { message = "User registered successfully.", statusCode = HttpStatusCode.OK });
            }
            else
            {
                return Json(new { message = "Invalid registration.", statusCode = HttpStatusCode.BadRequest });
            }
        }

        [HttpPost("validate")]
        public JsonResult validateLogin(LoginModel userCredentials)
        {
            var user = _facialBiometricsService.Login(userCredentials.username, userCredentials.password);

            if (user == null)
                return Json(new { isValid = false, message = "User Empty - Invalid username or password.", statusCode = HttpStatusCode.BadRequest });

            List<byte[]> imageData = new List<byte[]>();

            foreach (var img64 in userCredentials.face_images)
            {
                string[] imgDados = img64.Split(',');
                imageData.Add(Convert.FromBase64String(imgDados[1]));
            }

            bool resultFaceImgs = _facialBiometricsService.CompareImages(user.IdUser, imageData);
            if (resultFaceImgs)
            {
                return Json(new { isValid = true, levelAccess = user.UserPositionInfo.IdUserPosition });
            }
            else
            {
                return Json(new { isValid = false, message = "Invalid Biometric data.", statusCode = HttpStatusCode.BadRequest });
            }
        }

        [HttpGet("articles")]
        public JsonResult getArticles(int idUser)
        {
            Console.WriteLine(">getArticles: idUser(" + idUser + ")");

            List<ArticleModel> list_articles = _facialBiometricsService.GetArticles(idUser);

            return Json(new { listArticles = list_articles });
        }

        [HttpGet("levels")]
        public JsonResult getUserByLevel(int idPosition)
        {
            if (idPosition == 0)
                return Json(new { message = "User level not specified." });

            List<string> list_users = _facialBiometricsService.GetUsersByLevel(idPosition);

            return Json(new { message = "Job Leveling Successfully!", list_users = list_users });
        }
    }
}