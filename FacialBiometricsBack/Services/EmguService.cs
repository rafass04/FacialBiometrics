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
            Image<Gray, byte>[] imgsTraining = new Image<Gray, byte>[4];
            VectorOfMat imageList = new VectorOfMat();
            VectorOfInt labelList = new VectorOfInt();


            string pathUpload = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Uploads\\");
            DirectoryInfo dir = Directory.CreateDirectory(pathUpload);

            List<string> pathImgs = new List<string>();
            string pathImgReceived;

            pathImgReceived = pathUpload + "imgReceived" + ".jpeg";

            using (var fs = new FileStream(pathImgReceived, FileMode.Create, FileAccess.Write))
            {
                fs.Write(imgsRecebidas[0], 0, imgsRecebidas[0].Length);
            }

            try
            {

                foreach (var img in imgsDb)
                {
                    string path = pathUpload + img.IdUser + img.IdImg + ".jpeg";
                    pathImgs.Add(path);

                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(img.ImageBytes, 0, img.ImageBytes.Length);
                    }

                }

                for (int i = 0; i < imgsTraining.Length; i++)
                {
                    imgsTraining[i] = new Image<Gray, byte>(pathImgs[i]);
                    imageList.Push(imgsTraining[i].Mat);
                    labelList.Push(new[] { i });
                }

                Image<Gray, Byte> imagemRecebida = new Image<Gray, Byte>(pathImgReceived);

                EigenFaceRecognizer recognizer = new EigenFaceRecognizer(imageList.Size);//Altura 1280 e Largura 958

                recognizer.Train(imageList, labelList);
                EigenFaceRecognizer.PredictionResult result = recognizer.Predict(imagemRecebida.Resize(958,1280,Inter.Cubic));
                 
                var respostaEmgu = result.Label;

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                throw new Exception("Erro CompareImages: "+e.Message);
            }

            //retorno temporário
            return true;
        }
    }
}
