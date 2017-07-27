
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Domain.Entities
{
    public class Tag
    {
        public string Text { get; set; }
        public List<Post> Posts { get; set; }
    }
}