using FacialBiometrics.Models;
using FacialBiometricsBack.Models;
using FacialBiometricsBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
        public JsonResult CadastroUser(UserFrontModel dadosUser)
        {
            if (ModelState.IsValid)
            {
                if (dadosUser.face_images.Count()==0)
                {
                    return Json(new { message = "Nenhuma imagem recebida",statusCode=HttpStatusCode.BadRequest });
                }

                List<UserFaceImg> imageDados = new List<UserFaceImg>();

                foreach(var img in dadosUser.face_images)
                {
                    string[] imgDados = img.Split(',');

                    imageDados.Add(new UserFaceImg
                    {
                        metaData = imgDados[0],
                        extension = imgDados[0].Split(';')[0].Split('/')[1],
                        imageBytes = Convert.FromBase64String(imgDados[1])
                    });

                }


                int idUser = _facialBiometricsService.CreateUser(new UserInfo{
                    NameUser = dadosUser.name,
                    Username = dadosUser.username,
                    Password = dadosUser.password,
                    UserPositionInfo = new UserPosition{ IdUserPosition = dadosUser.id_user_position}
                });

                foreach(var faceImg in imageDados){
                    _facialBiometricsService.CreateFacialBiometrics(new UsersFacialBiometrics{
                        ImageName = Guid.NewGuid().ToString(),
                        ImageBytes = faceImg.imageBytes,
                        IdUser = idUser
                    });
                }

                return Json(new { message = "Cadastrado com sucesso", statusCode = HttpStatusCode.OK });
            }
            else
            {
                return Json(new { message = "Cadastro Inválido", statusCode = HttpStatusCode.BadRequest });
            }

        }

        [HttpPost("validate")]
        public JsonResult validateLogin(LoginModel userCredentials){

            var user = _facialBiometricsService.Login(userCredentials.username, userCredentials.password);

            if (user == null)
                return Json(new { isValid = false, message = "Invalid username or password", statusCode = HttpStatusCode.BadRequest });

            List<byte[]> imageDados = new List<byte[]>();

            //converte as imagens recebidas em 64 para bytes
            foreach (var img64 in userCredentials.face_images)
            {
                string[] imgDados = img64.Split(',');
                imageDados.Add(Convert.FromBase64String(imgDados[1]));
            }

            //fazer validação da biometria
            bool resultFaceImgs = _facialBiometricsService.CompareImages(user.IdUser,imageDados);
            if (resultFaceImgs)
            {
                return Json(new { isValid = true, levelAccess = user.UserPositionInfo.IdUserPosition });
            }
            else
            {
                return Json(new { isValid = false, message = "Invalid Biometric data", statusCode = HttpStatusCode.BadRequest });
            }            

         }

        [HttpGet("articles")]
        public JsonResult getArticles(int idUser){

            Console.WriteLine(">getArticles: idUser("+idUser+")");
            
            List<ArticleModel> list_articles = _facialBiometricsService.GetArticles(idUser);

            return Json(new { listArticles = list_articles });
        }

        [HttpGet("levels")]
        public JsonResult getUserByLevel (int idPosition)
        {
            if (idPosition == 0)
                return Json(new {message = "Nível não especificado." });

            List<string> list_users = _facialBiometricsService.GetUsersByLevel(idPosition);


            return Json(new { message ="Sucesso!", list_users = list_users });
        }

    }
}
