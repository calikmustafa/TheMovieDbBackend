using AutoMapper;
using TheMovieDbBackend.Core.DTO;
using TheMovieDbBackend.Core.Entity;

namespace TheMovieDbBackend.API.Helpers
{
    
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                //CreateMap<UserForRegisterDTO, User>();
            CreateMap<User, UserForRegisterDTO>();



        }
        }
    


}
