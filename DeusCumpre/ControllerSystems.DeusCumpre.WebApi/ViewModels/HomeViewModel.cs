using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.WebApi.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}