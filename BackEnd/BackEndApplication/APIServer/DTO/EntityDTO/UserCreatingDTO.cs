namespace APIServer.DTO.EntityDTO
{
    public class UserCreatingDTO
    {
        public string? fullName { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public bool? male { get; set; }
        public string? phoneNumber { get; set; }
        public string? password { get; set; }
        public string? dobStr { get; set; }
    }
}
