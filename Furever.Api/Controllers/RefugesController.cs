using AutoMapper;
using Furever.Entities.DataTransferObjects.Refuges;
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
    [Route("api/refuges")]
    [ApiController]
    public class RefugesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public RefugesController(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        // api/refuges
        // [Authorize] // This is needed to allow authorized users, we could of added [AllowAnonymous] instead to allow anyone to view information (Make it Public)
        [HttpGet]
        public async Task<IActionResult> GetRefuges()
        {
            // Get categories from repository, store the result in animals variable
            var refuge = await _unitOfWork.Refuge.GetRefuges();

            // Map Data Transfer Object To Entity (see Extensions/MappingProfile.cs), 
            var refugeDto = _mapper.Map<IEnumerable<RefugeDto>>(refuge);

            // Return Animals 
            return Ok(refugeDto);
        }

        // api/refuges/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RefugeDto>> GetRefuge(int id)
        {
            // Get refuge by id
            var refuge = await _unitOfWork.Refuge.GetRefuge(id);

            // Error Handler, if id not found return message to the logger
            if (refuge == null)
            {
                _logger.LogError($"Refuge with id: {id} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                // Map Refuge to Data Transfer Object if id is found in the database
                return _mapper.Map<RefugeDto>(refuge);
            }
        }

        // api/refuges
        [HttpPost]
        public async Task<ActionResult> CreateRefuge([FromBody] RefugeCreationDto refuge)
        {
            // Handle empty object request
            if (refuge == null)
            {
                _logger.LogError("RefugeCreationDto object sent from client is null.");
                return BadRequest("RefugeCreationDto object is null.");
            }

            // Map Refuge to Data Transfer Object
            var refugeEntity = _mapper.Map<Refuge>(refuge);

            // Create and save data to database
            await _unitOfWork.Refuge.CreateRefuge(refugeEntity);
            await _unitOfWork.SaveAsync();

            // Map Data Transfer Object to Entity, store the content in variable refugeToReturn
            var refugeToReturn = _mapper.Map<RefugeDto>(refugeEntity);

            return CreatedAtRoute("Id", new { id = refugeToReturn.Id }, refugeToReturn);
        }

        // api/refuges/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditRefuge(int id, [FromBody] RefugeCreationDto refuge)
        {
            // Error handler, log error if no refuge found with selected id
            if (refuge == null)
            {
                _logger.LogError($"Refuge with id: {id} doesn't exist in the database");
                return NotFound();
            }

            // If refuge id is found store it in variable  
            var refugeEntity = HttpContext.Items["refuge"] as Refuge;

            // Map Entity to Data Transfer Object, save and return
            _mapper.Map(refugeEntity, refuge);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        // api/refuges/5
        [HttpDelete]
        public async Task<ActionResult> DeleteRefuge(int id)
        {
            // Error handler if refuge not found in db
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Refuge with id: {id} doesn't exist in the database");
                return NotFound();
            }

            // Store refuge in variable refuge
            var refuge = HttpContext.Items["refuge"] as Refuge;

            // Delete refuge, save then return
            await _unitOfWork.Refuge.DeleteRefuge(refuge);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
