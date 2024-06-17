using AutoMapper;
using CouponsV2.Dtos;
using CouponsV2.Models;

namespace CouponsV2.Application.Utils.Profiles
{
    public class CouponsProfile : Profile
    {
        public CouponsProfile()
        {
            CreateMap<CouponsDTO, Coupon>().ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));;
        }
    }
}