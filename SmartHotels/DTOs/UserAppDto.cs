namespace SmartHotels.DTOs
{
    public class UserAppDto
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public short UserType { get; set; }
        public bool UserActive { get; set; } = true;
    }
}
