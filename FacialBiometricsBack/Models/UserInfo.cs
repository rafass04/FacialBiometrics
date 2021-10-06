namespace FacialBiometrics.Models
{
    public class UserInfo
    {
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SaltPassword { get; set; }
        public UserPosition UserPositionInfo { get; set; }
    }
}