using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using FacialBiometrics.Models;

namespace FacialBiometricsBack.Services
{
    public class EmguService
    {


        public bool CompareImages(List<UsersFacialBiometrics> imgsDb, List<byte[]> imgsRecebidas)
        {
            Image<Gray, Byte>[] imgsTraining = new Image<Gray, byte>[4];

            List<string> pathImgs = new List<string>();
            try
            {
                string caminho = @"./Uploads/";
                DirectoryInfo dir = Directory.CreateDirectory(caminho);


                foreach (var img in imgsDb)
                {
                    string path = caminho + img.IdUser + img.IdImg + ".jpeg";
                    pathImgs.Add(path);

                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(img.ImageBytes, 0, img.ImageBytes.Length);
                    }

                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            for (int i = 0; i < imgsTraining.Length; i++)
            {
                imgsTraining[i] = new Image<Gray, Byte>(pathImgs[i]);
            }

            int[] labels = new int[] { 0, 1, 2 };

            Image<Gray, Byte> imagemRecebida = new Image<Gray, Byte>(Encoding.ASCII.GetString(imgsRecebidas[0]));

            EigenFaceRecognizer recognizer = new EigenFaceRecognizer(0, 0.2);//definir o tamanho (largura e altura) da imagem recebida
            EigenFaceRecognizer.PredictionResult result = recognizer.Predict(imagemRecebida);

            var respostaEmgu = result.Label;
            
            //retorno temporário
            return true;
        }
    }
}
