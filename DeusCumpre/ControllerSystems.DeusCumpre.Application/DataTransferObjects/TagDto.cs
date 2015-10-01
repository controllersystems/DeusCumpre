using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Application.DataTransferObjects
{
    public class TagDto
    {
        public string Text { get; set; }
        public PostDto Post { get; set; }
        public virtual List<PostDto> Posts { get; set; }
    }
}