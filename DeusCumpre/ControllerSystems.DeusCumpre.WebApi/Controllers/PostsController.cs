using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Services;
using ControllerSystems.DeusCumpre.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControllerSystems.DeusCumpre.WebApi.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPublisherService iPublishService;

        public PostsController(IPublisherService iPublishService)
        {
            this.iPublishService = iPublishService;
        }

        // GET api/posts
        public IEnumerable<PostViewModel> Get()
        {
            return Mapper.Map<IEnumerable<PostDto>, IEnumerable<PostViewModel>>(iPublishService.GetAllPosts());
        }

        // GET api/posts/5
        public PostViewModel Get(int id)
        {
            var postViewModel = Mapper.Map<PostDto, PostViewModel>(iPublishService.GetById(id));
            if (postViewModel == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return postViewModel;
        }

        // POST api/posts
        public void Post(PostViewModel postViewModel)
        {
            this.iPublishService.Publish(Mapper.Map<PostViewModel, PostDto>(postViewModel));
        }

        // PUT api/posts/5
        public void Put(int id, PostViewModel postViewModel)
        {
            var post = Mapper.Map<PostDto, PostViewModel>(iPublishService.GetById(id));
            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                this.iPublishService.Edit(Mapper.Map<PostViewModel, PostDto>(postViewModel));
            }
        }

        // DELETE api/posts/5
        public void Delete(int id)
        {
            var postViewModel = Mapper.Map<PostDto, PostViewModel>(iPublishService.GetById(id));
            if (postViewModel == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                this.iPublishService.Delete(id);
            }
        }
    }
}
