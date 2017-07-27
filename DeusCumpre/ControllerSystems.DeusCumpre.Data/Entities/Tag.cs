
namespace ControllerSystems.DeusCumpre.Data.Entities
{
    public class Tag
    {
        public string Text { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}