﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Repositories;
using ControllerSystems.DeusCumpre.Application.Interfaces.Services;
using ControllerSystems.DeusCumpre.Domain.Entities;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Application.Services
{
	public class PublisherService : IPublisherService
	{
        private readonly IPostRepository iPostRepository;
        private readonly ITagRepository iTagRepository;

        public PublisherService(IPostRepository iPostRepository, ITagRepository iTagRepository)
        {
            this.iPostRepository = iPostRepository;
            this.iTagRepository = iTagRepository;
        }

		public virtual void Publish(PostDto postDto)
		{
            var post = Mapper.Map<PostDto, Post>(postDto);

            if (post.IsValid)
            {
                post.Publish();
                iPostRepository.Add(Mapper.Map<Post, PostDto>(post));
            }
		}

        public virtual void Delete(PostDto postDto)
		{
            iPostRepository.Delete(postDto.Id);
		}

        public virtual void Edit(PostDto postDto)
		{
            var post = Mapper.Map<PostDto, Post>(postDto);

            if (post.IsValid)
            {
                iPostRepository.Update(Mapper.Map<Post, PostDto>(post));
            }
		}

        public PostDto GetById(int id)
        {
            return iPostRepository.GetById(id);
        }

        public List<PostDto> GetAllPosts()
        {
            return iPostRepository.GetAll();
        }

        public List<TagDto> GetAllTags()
        {
            return iTagRepository.GetAllDistinct();
        }

        public void Delete(int id)
        {
            iPostRepository.Delete(id);
        }
    }
}