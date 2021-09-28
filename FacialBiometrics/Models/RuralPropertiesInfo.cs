using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometrics.Models
{
    public class RuralPropertiesInfo
    {
        public int IdProperty { get; set; }
        public string TextInformation { get; set; }
        public string ImageInformation { get; set; }
        public UserPosition Position { get; set; }
    }
}
