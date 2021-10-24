using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


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
        public List<string> face_images { get; set; }

        [Required]
        public int id_user_position { get; set; }

    }
}
