using FacialBiometricsBack.Models;
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
        public JsonResult GetTeste()
        {
            var dados = new
            {
                message = "Teste de api"
            };

            return Json(dados);
        }

        [HttpPost("Cadastro")]
        public JsonResult CadastroUser(UserFrontModel dadosUser )
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
                        metaDados = imgDados[0],
                        extensao = imgDados[0].Split(';')[0].Split('/')[1],
                        imageBytes = Convert.FromBase64String(imgDados[1])
                    });

                }


                // método cadastrar banco (dadosUserm, imageDados)
                //if ok return sucesso, else, message = "problema no cadastro"

                return Json(new { message = "Cadastrado com sucesso", statusCode = HttpStatusCode.OK });
            }
            else
            {
                return Json(new { message = "Cadastro Inválido", statusCode = HttpStatusCode.BadRequest });
            }

        }

    }
}
