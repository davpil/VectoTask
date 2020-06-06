using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VectoTask.Data;
using VectoTask.Models;

namespace VectoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();  
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Category> GetCategoryAsync(int id)
        {
            // 200(OK) if found an id
            // 204(No Content) if there is no such id
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateCategoryAsync ([FromBody] Category model)
        {
             _context.Categories.Add(model);
             int a =  await _context.SaveChangesAsync();

            if (a!=1)
                return BadRequest(ModelState);

            return CreatedAtAction(
               nameof(GetCategoryAsync),
               new { id = model.Id },
               model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateCategoryAsync ([FromBody] Category model)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (category ==null)
                return NotFound();

            category = model;
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (category == null)
                return NotFound();

             _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}