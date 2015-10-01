using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.WebApi.ViewModels
{
    public class HomeViewModel
    {
        public List<PostViewModel> Posts { get; set; }
        public List<TagViewModel> Tags { get; set; }
    }
}