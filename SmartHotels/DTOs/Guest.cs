namespace SmartHotels.DTOs
{
    public class Guest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LasttName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ConcactPhone { get; set; } = string.Empty;
    }
}
