using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Services;
using ControllerSystems.DeusCumpre.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using ControllerSystems.DeusCumpre.WebApi.ViewModels;
using AutoMapper;

namespace ControllerSystems.DeusCumpre.WebApi.Controllers
{
    public class TagsController : ApiController
    {
        private readonly IPublisherService iPublishService;

        public TagsController(IPublisherService iPublishService)
        {
            this.iPublishService = iPublishService;
        }

        // GET api/tag
        public List<TagViewModel> GetAllTags()
        {
            return Mapper.Map<List<TagDto>, List<TagViewModel>>(iPublishService.GetAllTags());
        }

        public List<PostViewModel> GetAllTags(string name)
        {
            return Mapper.Map<List<PostDto>, List<PostViewModel>>(iPublishService.GetAllPosts().Where(x => x.Tags.Contains(name)).ToList());
        }

    }
}
