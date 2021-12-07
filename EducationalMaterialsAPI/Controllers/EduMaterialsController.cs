using AutoMapper;
using EducationalMaterialsAPI.Data.DTOs.EduMaterialDtos;
using EducationalMaterialsAPI.Data.Repository;
using EducationalMaterialsAPI.Logger.Extensions;
using EducationalMaterialsAPI.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalMaterialsAPI.Controllers
{
    [Route("materials")]
    [Authorize]
    [ApiController]
    public class EduMaterialsController : ControllerBase
    {
        private readonly ILogger<EduMaterialsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepo<EduMaterial> _materialsRepo;

        public EduMaterialsController(ILogger<EduMaterialsController> logger, IMapper mapper, IRepo<EduMaterial> materialsRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _materialsRepo = materialsRepo;
        }


        // GET materials
        [HttpGet]
        public async Task<ActionResult<ICollection<EduMaterialReadDto>>> GetAllMaterials()
        {
            _logger.LogInfo(HttpContext.User, nameof(GetAllMaterials));
            var materialsModels = await _materialsRepo.GetAll();
            if(materialsModels == null || materialsModels.Count < 1)
            {
                return NotFound();
            }
            var materialsReadDto = _mapper.Map<ICollection<EduMaterialReadDto>>(materialsModels);
            return Ok(materialsReadDto);
        }


        // GET materials/{id}
        [HttpGet("{id}", Name = "GetMaterial")]
        public async Task<ActionResult<EduMaterialReadDto>> GetMaterial(int id)
        {
            _logger.LogInfo(HttpContext.User, nameof(GetMaterial));
            var materialModel = await _materialsRepo.Get(id);
            if(materialModel == null)
            {
                return BadRequest();
            }
            var materialReadDto = _mapper.Map<EduMaterialReadDto>(materialModel);
            return Ok(materialReadDto);
        }

        // POST materials
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EduMaterialReadDto>> CreateEduMaterial(EduMaterialCreateDto eduMaterialCreateDto)
        {
            _logger.LogInfo(HttpContext.User, nameof(CreateEduMaterial));
            var materialModel = _mapper.Map<EduMaterial>(eduMaterialCreateDto);
            await _materialsRepo.Add(materialModel);
            var materialReadDto = _mapper.Map<EduMaterialReadDto>(materialModel);
            return CreatedAtRoute(nameof(GetMaterial), new { id = materialModel.Id }, materialReadDto);
        }

        // PUT materials/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateEduMaterial(int id, EduMaterialUpdateDto eduMaterialUpdateDto)
        {
            _logger.LogInfo(HttpContext.User, nameof(UpdateEduMaterial));
            var materialModel = await _materialsRepo.Get(id);
            if (materialModel == null)
            {
                return NotFound();
            }
            _mapper.Map(eduMaterialUpdateDto, materialModel);
            await _materialsRepo.Update(materialModel);
            return NoContent();
        }

        // DELETE materials/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEduMaterial(int id)
        {
            _logger.LogInfo(HttpContext.User, nameof(DeleteEduMaterial));
            var materialModel =  await _materialsRepo.Get(id);
            if (materialModel == null)
            {
                return NotFound();
            }

            await _materialsRepo.Delete(materialModel);
            return NoContent();
        }
    }
}
