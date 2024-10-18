using FoodCourt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourt.Services
{
    public interface IMenuService
    {
        Task<List<MenuDTO>>GetAllMenu();
        Task<MenuDTO> AddMenu(MenuDTO menuDTO);
        Task<MenuDTO> EditMenu(int menuId, MenuDTO menuDTO); 
        Task<bool> RemoveMenu(int menuId); 

    }
}
