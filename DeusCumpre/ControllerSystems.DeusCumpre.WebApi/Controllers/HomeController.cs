using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Services;
using ControllerSystems.DeusCumpre.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerSystems.DeusCumpre.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPublisherService iPublishService;

        public HomeController(IPublisherService iPublishService)
        {
            this.iPublishService = iPublishService;
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Posts = Mapper.Map<IEnumerable<PostDto>, IEnumerable<PostViewModel>>(iPublishService.GetAll().Take(5));

            return View(model);
        }
    }
}