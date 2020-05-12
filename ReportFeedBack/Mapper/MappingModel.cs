using AutoMapper;
using ReportFeedBack.Data.Entity;
using ReportFeedBack.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Mapper
{
    public class MappingModel: Profile
    {
        public MappingModel()
        {
            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<Comment, CommentVm>().ForMember(src => src.UserName, dest => dest.MapFrom(s => s.User.UserName)).ReverseMap();
            CreateMap<Post, PostVm>().ReverseMap();
            CreateMap<Post, VmPostEntry>().ReverseMap();
            CreateMap<Comment, VmCommentEntry>().ReverseMap();
            CreateMap<Comment, VmCommentResult>();


        }
    }
}
