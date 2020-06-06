using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VectoTask.Data;
using VectoTask.Models;
using VectoTask.Dtos;

namespace VectoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TourCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        //TourCategories/GetToursByCategory/1
        //[HttpGet("{id}")]
        //public async Task<IEnumerable<TourCategoryDto>> GetToursByCategory(int categoryId)
        //{
        //    TourCategoryDto model = await _context.TourCategories.Include(x => x.Category)
        //                                            .Include(x => x.Tour)
        //                                            .Where(x => x.CategoryId == categoryId)
        //                                            .Select(x=> new TourCategoryDto
        //                                            { 
        //                                            }).ToListAsync();


      
        //    return Ok();
        //}
    }
}
