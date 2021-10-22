using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometricsBack.Models
{
    public class UserFaceImg
    {
        public string metaData { get; set; }
        public string extension { get; set; }
        public Byte[] imageBytes { get; set; }
    }
}