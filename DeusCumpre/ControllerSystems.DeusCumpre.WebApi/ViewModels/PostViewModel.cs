
using System;
using System.Collections.Generic;
namespace ControllerSystems.DeusCumpre.WebApi.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public UserViewModel User { get; set; }
        public List<String> Tags { get; set; }
    }
}