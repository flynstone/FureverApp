using AutoMapper;
using Furever.Entities.DataTransferObjects.Categories;
using Furever.Entities.Models;
using Furever.LoggerService;
using Furever.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furever.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // api/categories
        // [Authorize] // This is needed to allow authorized users, we could of added [AllowAnonymous] instead to allow anyone to view information (Make it Public)
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            // Get categories from repository, store the result in animals variable
            var category = await _unitOfWork.Category.GetCategories();

            // Map Data Transfer Object To Entity (see Extensions/MappingProfile.cs), 
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(category);

            // Return Animals 
            return Ok(categoryDto);
        }

        // api/categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            // Get category by id
            var category = await _unitOfWork.Category.GetCategory(id);

            // Error Handler, if id not found return message to the logger
            if (category == null)
            {
                _logger.LogError($"Category with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                // Map Animal to Data Transfer Object if id is found in the database
                return _mapper.Map<CategoryDto>(category);
            }
        }

        // api/categories
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryCreationDto category)
        {
            // Handle empty object request
            if (category == null)
            {
                _logger.LogError("CategoryCreationDto object sent from client is null.");
                return BadRequest("CategoryCreationDto object is null.");
            }

            // Map Animal to Data Transfer Object
            var categoryEntity = _mapper.Map<Category>(category);

            // Create and save data to database
            await _unitOfWork.Category.CreateCategory(categoryEntity);
            await _unitOfWork.SaveAsync();

            // Map Data Transfer Object to Entity, store the content in variable animalToReturn
            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("Id", new { id = categoryToReturn.Id }, categoryToReturn);
        }

        // api/categories/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditCategory(int id, [FromBody] CategoryCreationDto category)
        {
            // Error handler, log error if no category found with selected id
            if (category == null)
            {
                _logger.LogError($"Category with id: {id} doesn't exist in the database");
                return NotFound();
            }

            // If category id is found store it in variable  
            var categoryEntity = HttpContext.Items["category"] as Category;

            // Map Entity to Data Transfer Object, save and return
            _mapper.Map(categoryEntity, category);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // api/categories/5
        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            // Error handler if category not found in db
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Category with id: {id} doesn't exist in the database");
                return NotFound();
            }

            // Store category in variable category
            var category = HttpContext.Items["category"] as Category;

            // Delete animal, save then return
            await _unitOfWork.Category.DeleteCategory(category);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
