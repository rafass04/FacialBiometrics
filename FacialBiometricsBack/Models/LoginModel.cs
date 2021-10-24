using System;
using System.Collections.Generic;

namespace FacialBiometrics.Models
{
    public class LoginModel{
        public string username { get; set; }
        public string password { get; set; }
        public List<string> face_images { get; set; }
    }
}