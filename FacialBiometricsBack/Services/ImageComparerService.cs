using System;
using System.Collections.Generic;
using System.IO;
using FacialBiometrics.Models;
using System.Diagnostics;

namespace FacialBiometricsBack.Services
{
    public class ImageComparerService
    {
        private string TempPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TempUploads\\");

        public bool CompareImages(List<UsersFacialBiometrics> imgsDb, List<byte[]> imgsRecebidas)
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