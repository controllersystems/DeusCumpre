using System;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
