using AutoMapper;
using CatFishingWebSite.Model;

namespace CatFishingWebSite.wwwroot
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, IdOfUser>();
        }
    }
}
