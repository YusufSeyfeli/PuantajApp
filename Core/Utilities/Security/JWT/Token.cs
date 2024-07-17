namespace Core.Utilities.Security.JWT
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserGuidId{ get; set; }
        public bool MyClaim { get; set; }
    }
}
