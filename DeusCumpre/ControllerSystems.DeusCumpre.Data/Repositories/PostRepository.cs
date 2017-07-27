﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Repositories;
using ControllerSystems.DeusCumpre.Data.Context;
using ControllerSystems.DeusCumpre.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace ControllerSystems.DeusCumpre.Data.Repositories
{
    public class PostRepository : RepositoryBase<PostDto, Post>, IPostRepository
    {
        public override void Add(PostDto tEntityDto)
        {
            try
            {
                using (DeusCumpreContext db = new DeusCumpreContext())
                {
                    var post = Convert(tEntityDto);
                    var user = db.User.Where(x => x.Login == tEntityDto.User.Login).FirstOrDefault();
                    if (user != null)
                        post.User = user;
                    db.Post.Add(post);
                    if (post.Tags != null)
                        foreach (var item in post.Tags)
                        {
                            item.Post = post;
                            //item.PostId = post.Id;
                            //db.Tag.Add(item);
                        }
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                string text = string.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {
                    text += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        text += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(text);
            }
        }

        public override void Update(PostDto tEntityDto)
        {
            using (DeusCumpreContext db = new DeusCumpreContext())
            {
                var post = Convert(tEntityDto);
                post.User = db.User.Where(x => x.Login == tEntityDto.User.Login).FirstOrDefault();
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (DeusCumpreContext db = new DeusCumpreContext())
            {
                var post = db.Post.Where(x => x.Id == id).FirstOrDefault();
                if (post != null)
                {
                    db.Post.Remove(post);
                    db.SaveChanges();
                }
            }
        }

        public override List<PostDto> GetAll()
        {
            using (DeusCumpreContext db = new DeusCumpreContext())
            {
                return Convert(db.Post.Include("User").Include("Tags").ToList());
            }
        }
    }
}