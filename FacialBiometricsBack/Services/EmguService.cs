using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace FacialBiometricsBack.Services
{
    public class EmguService
    {


        public bool CompareImages(List<byte[]> imgsDb, List<byte[]> imgsRecebidas)
        {
            Image<Gray, Byte>[] imgsTraining = new Image<Gray, byte>[3];

            for(int i = 0; i < imgsTraining.Length; i++)
            {
                imgsTraining[i] = new Image<Gray, Byte>(Encoding.ASCII.GetString(imgsDb[i]));
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
