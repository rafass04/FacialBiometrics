using System;

namespace FacialBiometricsBack.Models
{
    public class UserFaceImg
    {
        public string metaData { get; set; }
        public string extension { get; set; }
        public Byte[] imageBytes { get; set; }
    }
}