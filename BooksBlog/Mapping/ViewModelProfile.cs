using AutoMapper;
using BooksBlog.Areas.Administration.ViewModels;
using BooksBlog.Models;
using BooksBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksBlog.Mapping
{
    public class ViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>();
            CreateMap<Post, GuestPostViewModel>();
            CreateMap<GuestPostViewModel, Post>();
            CreateMap<Categories, CategoryViewModel>();
            CreateMap<CategoryViewModel, Categories>();
            CreateMap<Comments, CommentViewModel>();
            CreateMap<CommentViewModel, Comments>();

        }
    }
}