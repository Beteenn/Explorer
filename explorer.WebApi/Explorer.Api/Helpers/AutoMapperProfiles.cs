using AutoMapper;
using Explorer.Api.Dtos;
using Explorer.Domain;

namespace Explorer.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
        }

    }
}