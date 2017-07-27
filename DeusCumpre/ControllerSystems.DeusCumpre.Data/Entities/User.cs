
namespace ControllerSystems.DeusCumpre.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}