using AutoMapper;
using FoodCourt.DTO;
using FoodCourtData.Models;

namespace FoodCourt.Common
{
    public class FoodCourtMapper : Profile
    {
        public FoodCourtMapper()
        {
            CreateMap<MenuDTO, Menu>();
        }
    }
}
