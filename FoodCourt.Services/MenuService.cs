using AutoMapper;
using FoodCourt.DTO;
using FoodCourtData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourt.Services
{
    public class MenuService : IMenuService
    {
        private readonly LalatdigitallibraryFoodCourtDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public MenuService(LalatdigitallibraryFoodCourtDbContext context, IConfiguration config , IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Define a mapping from Menu to MenuDTO
                CreateMap<Menu, MenuDTO>();
            }
        }
        public async Task<List<MenuDTO>> GetAllMenu()
        {
            var menus=await _context.Menus.ToListAsync();
            var menuDTOs = _mapper.Map<List<MenuDTO>>(menus);
            return menuDTOs;
        }

        public async Task<MenuDTO> AddMenu(MenuDTO menuDTO)
        {
            var category = await _context.Categories.FindAsync(menuDTO.CategoryId);
            if (category == null)
            {
                throw new ArgumentException("Invalid category ID.");
            }
            var menu = new Menu
            {
                ItemName = menuDTO.ItemName,
                Description = menuDTO.Description,
                Price = menuDTO.Price,
                Category= category,
                ImageUrl = menuDTO.ImageUrl,
                IsAvailable = menuDTO.IsAvailable,
                CreatedAt = menuDTO.CreatedAt,
            };
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
            menuDTO.ItemId = menu.ItemId; // Set the ItemId in the DTO after saving
            return menuDTO;
        }
        public async Task<MenuDTO> EditMenu(int menuId, MenuDTO menuDTO)
        {
            var menu = await _context.Menus.FirstOrDefaultAsync(m => m.ItemId == menuId);
            menu.ItemName= menuDTO.ItemName;
            menu.Description= menuDTO.Description;
            menu.Price= menuDTO.Price;
            menu.CategoryId= menuDTO.CategoryId;
            menu.ImageUrl= menuDTO.ImageUrl;
            menu.IsAvailable= menuDTO.IsAvailable;
            menu.CreatedAt= menuDTO.CreatedAt;
             _context.SaveChanges();
            var UpdatedMenu=_mapper.Map<MenuDTO>(menuDTO);  // Map the updated menu entity back to a MenuDTO
            return UpdatedMenu;
        }
        public async Task<bool>RemoveMenu(int menuId)
        {
            var menu= await _context.Menus.FirstOrDefaultAsync(m => m.ItemId==menuId);
            _context.Menus.Remove(menu);
            _context.SaveChangesAsync();
            return true;
        }
        
    }
}
