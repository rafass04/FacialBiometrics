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
using System.Diagnostics;
using IronPython.Hosting;

namespace FacialBiometricsBack.Services
{
    public class FacialService
    {
        private string TempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TempUploads\\");

        public bool CompareImages(List<UsersFacialBiometrics> imgsDb, List<byte[]> imgsRecebidas)
        {
            Image<Gray, byte>[] imgsTraining = new Image<Gray, byte>[3];
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
                EigenFaceRecognizer.PredictionResult result = recognizer.Predict(imagemRecebida);
                 
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

        public bool NewCompareImages(List<UsersFacialBiometrics> imgsDb, List<byte[]> imgsRecebidas)
        {
            try
            {
                if (imgsDb == null || imgsRecebidas == null) throw new ArgumentNullException();

                var pathUploadDatabase = TempPath + "Database\\";
                var pathUploadReceived = TempPath + "Received\\";

                if (!Directory.Exists(pathUploadDatabase))
                    Directory.CreateDirectory(pathUploadDatabase);

                if (!Directory.Exists(pathUploadReceived))
                    Directory.CreateDirectory(pathUploadReceived);

                pathUploadReceived = pathUploadReceived + "received_image.jpeg";
                pathUploadDatabase = pathUploadDatabase + "database_image.jpeg";

                CreateTempImage(pathUploadReceived, imgsRecebidas[0], imgsRecebidas[0].Length);
                CreateTempImage(pathUploadDatabase, imgsDb[0].ImageBytes, imgsDb[0].ImageBytes.Length);
                
                var result = RunPythonScript();

                DeleteTempPath(TempPath);

                if (result.Contains("true"))
                    return true;
                else if (result.Contains("false"))
                    return false;
                else
                    throw new Exception("Error executing the python face recognition engine.");
            }
            catch (Exception e)
            {
                throw new Exception("Erro CompareImages: " + e.Message);
            }
        }

        private string RunPythonScript()
        {
            Process process = new Process();

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            process.StandardInput.WriteLine("cd C:\\Users\\Luiz\\source\\repos\\FacialBiometrics\\myenvpy\\Scripts\\");
            process.StandardInput.WriteLine("activate");
            process.StandardInput.WriteLine("python execute_face_recognition.py");
            process.StandardInput.Flush();
            process.StandardInput.Close();

            return process.StandardOutput.ReadToEnd();
        }

        private void CreateTempImage(string path, byte[] image, int imageLength)
        {
            if (!File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(image, 0, imageLength);
                }
            }
        }

        private void DeleteTempPath(string path)
        {
            var directories = Directory.GetDirectories(path);
                        
            foreach (var directory in directories)
            {
                DeleteTempPath(directory);                                            
            }

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            Directory.Delete(path);
        }
    }
}
