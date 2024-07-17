namespace Entities.Dtos.AuthDtos
{
    public class UserChangePasswordDto
    {
        public Guid UserGuidId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}