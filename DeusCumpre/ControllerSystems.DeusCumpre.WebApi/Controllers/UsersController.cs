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
    public class UsersController : ApiController
    {
        private readonly IAuthenticationService iAuthenticationService;

        public UsersController(IAuthenticationService iAuthenticationService)
        {
            this.iAuthenticationService = iAuthenticationService;
        }

        // POST api/users
        public void Post(UserViewModel userViewModel)
        {
            this.iAuthenticationService.Create(Mapper.Map<UserViewModel, UserDto>(userViewModel));
        }

        // POST api/users
        public bool Login(string login, string password)
        {
            return this.iAuthenticationService.LogIn(login, password);
        }

        public void LogOut(string login)
        {
            this.iAuthenticationService.LogOut();
        }

        //// PUT api/users/5
        //public void Put(int id, UserViewModel userViewModel)
        //{
        //    var post = Mapper.Map<PostDto, PostViewModel>(iAuthenticationService.GetById(id));
        //    if (post == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    else
        //    {
        //        this.iPublishService.Edit(Mapper.Map<PostViewModel, PostDto>(postViewModel));
        //    }
        //}

        //// DELETE api/users/5
        //public void Delete(int id)
        //{
        //}
    }
}
