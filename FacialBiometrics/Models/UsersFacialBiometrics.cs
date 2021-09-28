using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometrics.Models
{
    public class UsersFacialBiometrics
    {
        public int IdImg { get; set; }
        public string Image { get; set; }
        public UserInfo User { get; set; }
    }
}
