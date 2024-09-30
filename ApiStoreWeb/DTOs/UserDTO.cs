namespace ApiStoreWeb.DTOs
{
    public class UserSession
    {
        public string Username { get; set; } = null!;

        public string Userpassword { get; set; } = null!;
    }
    public class CategoryResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
