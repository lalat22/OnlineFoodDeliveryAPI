using FoodCourt.DTO;
using FoodCourt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuService _menuservice;
        public MenusController(IMenuService menuservice)
        {
            _menuservice = menuservice;
        }
        [HttpGet("GetAllMenus")]
        public async Task<ActionResult<List<MenuDTO>>> GetAllMenu()
        {
            var menus=await _menuservice.GetAllMenu();
            return Ok(menus);
        }
        [HttpPost("AddMenus")]
        public async Task<ActionResult<MenuDTO>> AddMenu(MenuDTO menuDTO)
        {
            var menus=await _menuservice.AddMenu(menuDTO);
            return Ok(menus);
        }
        [HttpPost("UpdateMenu")]
        public async Task<ActionResult<MenuDTO>> EditMenu(int menuId, MenuDTO menuDTO)
        {
            var updatedmenus=await _menuservice.EditMenu(menuId, menuDTO);
            return Ok(updatedmenus);
        }
        [HttpDelete("DeleteMenu")]
        public async Task<ActionResult<bool>> RemoveMenu(int menuId)
        {
            var removedmenu=await _menuservice.RemoveMenu(menuId);
            return Ok(removedmenu);
        }
    }
}
