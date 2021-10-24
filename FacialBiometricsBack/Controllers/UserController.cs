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

        [HttpGet]
        public JsonResult GetTeste()
        {
            var dados = new
            {
                message = "Teste de api"
            };            

            return Json(dados);
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

            //fazer validação da biometria
            //...
            //caso sucesso retorna
            return Json(new { isValid = true, levelAccess = user.UserPositionInfo.IdUserPosition });

            //caso a biometria falhe
            return Json(new { isValid = false, message = "Invalid username or password", statusCode = HttpStatusCode.BadRequest });
         }

        [HttpGet("articles")]
        public JsonResult getArticles(int idUser){
            //SELECT * FROM ARTIGOS A WHERE A.NIVEL_ACESSO IN (SELECT U.LEVEL FROM USUARIO U WHERE U.ID = ID_USER)
            //Fazer query no banco que busca os artigos liberados pro nível do idUser passado

            Console.WriteLine(">getArticles: idUser("+idUser+")");
            
            List<ArticleModel> list_articles = _facialBiometricsService.GetArticles(idUser);

            return Json(new { listArticles = list_articles });
        }

    }
}
