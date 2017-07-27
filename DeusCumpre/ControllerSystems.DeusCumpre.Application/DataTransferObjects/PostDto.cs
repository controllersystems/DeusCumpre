
using ControllerSystems.DeusCumpre.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Application.DataTransferObjects
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public UserDto User { get; set; }
        public List<string> Tags { get; set; }
    }
}
