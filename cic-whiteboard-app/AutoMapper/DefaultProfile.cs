using AutoMapper;
using CIC.WhiteboardApp.Data.Entities;
using CIC.WhiteboardApp.Dtos;


namespace CIC.WhiteboardApp.AutoMapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {

            CreateMap<Post, PostDto>();
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();

            CreateMap<User, UserDto>();
            CreateMap<UserComment, UserCommentDto>();
            CreateMap<UserReaction, UserReactionDto>();
        }
    }
}
