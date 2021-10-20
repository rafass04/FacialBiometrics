using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometricsBack.Models
{
    public class UserFaceImg
    {
        public string metaDados { get; set; }
        public string extensao { get; set; }
        public Byte[] imageBytes { get; set; }
    }
}
