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
        private readonly IAuthenticationService iAuthenticationService;

        public HomeController(IPublisherService iPublishService, IAuthenticationService iAuthenticationService)
        {
            this.iPublishService = iPublishService;
            this.iAuthenticationService = iAuthenticationService;
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Posts = Mapper.Map<List<PostDto>, List<PostViewModel>>(iPublishService.GetAllPosts().Take(5).ToList());

            model.Tags = Mapper.Map<List<TagDto>, List<TagViewModel>>(iPublishService.GetAllTags().ToList());

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            var userDto = Mapper.Map<UserViewModel, UserDto>(user);
            try
            {
                iAuthenticationService.Create(userDto);
            }
            catch (ArgumentException argEx)
            {
                ModelState.AddModelError(argEx.ParamName, argEx.Message);
            }

            return View();
        }
    }
}