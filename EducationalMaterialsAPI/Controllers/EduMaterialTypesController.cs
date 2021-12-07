using AutoMapper;
using EducationalMaterialsAPI.Data.DTOs.EduMaterialTypeDtos;
using EducationalMaterialsAPI.Data.Repository;
using EducationalMaterialsAPI.Logger.Extensions;
using EducationalMaterialsAPI.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalMaterialsAPI.Controllers
{
    [Authorize]
    [Route("materials/types")]
    [ApiController]
    public class EduMaterialTypesController : ControllerBase
    {
        private readonly ILogger<EduMaterialTypesController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepo<EduMaterialType> _typesRepo;
        public EduMaterialTypesController(ILogger<EduMaterialTypesController> logger, IMapper mapper, IRepo<EduMaterialType> typesRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _typesRepo = typesRepo;
        }

        // GET materials/types
        [HttpGet]
        public async Task<ActionResult<ICollection<EduMaterialTypeReadDto>>> GetAllTypes()
        {
            _logger.LogInfo(HttpContext.User, nameof(GetAllTypes));
            var typesModels = await _typesRepo.GetAll();
            if (typesModels == null || typesModels.Count < 1)
            {
                return NotFound();
            }
            var typesReadDto = _mapper.Map<ICollection<EduMaterialTypeReadDto>>(typesModels);
            return Ok(typesReadDto);
        }


        // GET materials/types/{id}
        [HttpGet("{id}", Name = "GetMaterialType")]
        public async Task<ActionResult<EduMaterialTypeReadDto>> GetMaterialType(int id)
        {
            _logger.LogInfo(HttpContext.User, nameof(GetMaterialType));
            var typeModel = await _typesRepo.Get(id);
            if (typeModel == null)
            {
                return BadRequest();
            }
            var typeReadDto = _mapper.Map<EduMaterialTypeReadDto>(typeModel);
            return Ok(typeReadDto);
        }

        // POST materials/types
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EduMaterialTypeReadDto>> CreateEduMaterialType(EduMaterialTypeCreateDto eduMaterialTypeCreateDto)
        {
            _logger.LogInfo(HttpContext.User, nameof(CreateEduMaterialType));
            var typeModel = _mapper.Map<EduMaterialType>(eduMaterialTypeCreateDto);
            await _typesRepo.Add(typeModel);
            var typeReadDto = _mapper.Map<EduMaterialTypeReadDto>(typeModel);
            return CreatedAtRoute(nameof(GetMaterialType), new { id = typeModel.Id }, typeReadDto);
        }

        // PUT materials/types/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateEduMaterialType(int id, EduMaterialTypeUpdateDto eduMaterialTypeUpdateDto)
        {
            _logger.LogInfo(HttpContext.User, nameof(UpdateEduMaterialType));
            var typeModel = await _typesRepo.Get(id);
            if (typeModel == null)
            {
                return NotFound();
            }
            _mapper.Map(eduMaterialTypeUpdateDto, typeModel);
            await _typesRepo.Update(typeModel);
            return NoContent();
        }

        // DELETE materials/types/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEduMaterialType(int id)
        {
            _logger.LogInfo(HttpContext.User, nameof(DeleteEduMaterialType));
            var typeModel = await _typesRepo.Get(id);
            if (typeModel == null)
            {
                return NotFound();
            }

            await _typesRepo.Delete(typeModel);
            return NoContent();
        }

    }
}
