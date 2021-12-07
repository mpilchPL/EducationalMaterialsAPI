using AutoMapper;
using EducationalMaterialsAPI.Data.DTOs.AuthorDtos;
using EducationalMaterialsAPI.Data.Repository;
using EducationalMaterialsAPI.Logger.Extensions;
using EducationalMaterialsAPI.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EducationalMaterialsAPI.Controllers
{

    [Authorize]
    [Route("authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepo<Author> _authorsRepo;

        public AuthorsController(ILogger<AuthorsController> logger, IMapper mapper, IRepo<Author> authorsRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _authorsRepo = authorsRepo;
        }

        // GET authors
        [HttpGet]
        public async Task<ActionResult<ICollection<AuthorReadDto>>> GetAllAuthors()
        {
            _logger.LogInfo(HttpContext.User, nameof(GetAllAuthors));
            var authorModels = await _authorsRepo.GetAll();
            if (authorModels == null)
            {
                return NotFound();
            }
            var authorsReadDto = _mapper.Map<ICollection<AuthorReadDto>>(authorModels);
            return Ok(authorsReadDto);
        }

        // GET authors/{id}
        [HttpGet("{id}", Name = "GetAuthor")]
        public async Task<ActionResult<AuthorReadDto>> GetAuthor(int id)
        {
            _logger.LogInfo(HttpContext.User, nameof(GetAuthor));
            var authorModel = await _authorsRepo.Get(id);
            if (authorModel == null)
            {
                return BadRequest();
            }
            var authorReadDto = _mapper.Map<AuthorReadDto>(authorModel);
            return Ok(authorReadDto);
        }

        // POST authors
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AuthorReadDto>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            _logger.LogInfo(HttpContext.User, nameof(CreateAuthor));
            var authorModel = _mapper.Map<Author>(authorCreateDto);
            await _authorsRepo.Add(authorModel);
            var authorReadDto = _mapper.Map<AuthorReadDto>(authorModel);
            return CreatedAtRoute(nameof(GetAuthor), new { id = authorModel.Id }, authorReadDto);
        }

        // PUT authors/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAuthor(int id, AuthorUpdateDto authorUpdateDto)
        {
            _logger.LogInfo(HttpContext.User, nameof(UpdateAuthor));
            var authorModel = await _authorsRepo.Get(id);
            if (authorModel == null)
            {
                return NotFound();
            }
            _mapper.Map(authorUpdateDto, authorModel);
            await _authorsRepo.Update(authorModel);
            return NoContent();
        }

        // PATCH authors/{id}
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PatchAuthor(int id, JsonPatchDocument<AuthorUpdateDto> patchAuthor)
        {
            _logger.LogInfo(HttpContext.User, nameof(PatchAuthor));
            var authorModel = await _authorsRepo.Get(id);
            if (authorModel == null)
            {
                return NotFound();
            }

            var authorUpdateDto = _mapper.Map<AuthorUpdateDto>(authorModel);
            patchAuthor.ApplyTo(authorUpdateDto, ModelState);

            if(!TryValidateModel(authorUpdateDto))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(authorUpdateDto, authorModel);
            await _authorsRepo.Update(authorModel);
            return NoContent();
        }

        // DELETE authors/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            _logger.LogInfo(HttpContext.User, nameof(DeleteAuthor));
            var authorModel = await _authorsRepo.Get(id);
            if (authorModel == null)
            {
                return NotFound();
            }

            await _authorsRepo.Delete(authorModel);
            return NoContent();
        }
    }
}
