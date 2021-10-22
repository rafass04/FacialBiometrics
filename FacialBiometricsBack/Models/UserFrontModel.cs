using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacialBiometricsBack.Models
{
    public class UserFrontModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string salt_password { get; set; }

        [Required]
        public List<string> face_images { get; set; }

    }
}
