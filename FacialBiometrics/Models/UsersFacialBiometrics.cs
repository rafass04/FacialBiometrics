namespace FacialBiometrics.Models
{
    public class UsersFacialBiometrics
    {
        public int IdImg { get; set; }
        public string Image { get; set; }
        public UserInfo User { get; set; }
    }
}