using System;

namespace FacialBiometrics.Models
{
    public class UsersFacialBiometrics
    {
        public int IdImg { get; set; }
        public string ImageName { get; set; }
        public Byte[] ImageBytes { get; set; }
        public int IdUser { get; set; }
    }
}