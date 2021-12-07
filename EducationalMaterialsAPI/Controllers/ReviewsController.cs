using AutoMapper;
using EducationalMaterialsAPI.Data.DTOs.ReviewDtos;
using EducationalMaterialsAPI.Data.Repository;
using EducationalMaterialsAPI.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalMaterialsAPI.Controllers
{
    [Authorize]
    [Route("materials/{materialId}/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepo<Review> _reviewRepo;
        public ReviewsController(ILogger<ReviewsController> logger, IMapper mapper, IRepo<Review> reviewRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _reviewRepo = reviewRepo;
        }

        // GET materials/{materialId}/reviews
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<ReviewReadDto>>> GetAllReviewsOfMaterial(int materialId)
        {
            var reviewModels = await _reviewRepo.GetAll(x => x.EduMaterialId == materialId);
            if (reviewModels == null || reviewModels.Count < 1)
            {
                return NotFound();
            }
            var revireReadDto = _mapper.Map<ICollection<ReviewReadDto>>(reviewModels);
            return Ok(revireReadDto);
        }


        // GET materials/{materialId}/reviews/{reviewId}
        [HttpGet("{reviewId}", Name = "GetReview")]
        [AllowAnonymous]
        public async Task<ActionResult<ReviewReadDto>> GetReview(int materialId, int reviewId)
        {
            var reviewModel = await _reviewRepo.Get(reviewId);
            if (reviewModel == null)
            {
                return BadRequest();
            }
            var reviewReadDto = _mapper.Map<ReviewReadDto>(reviewModel);
            return Ok(reviewReadDto);
        }

        // POST materials/{materialId}/reviews
        [HttpPost]
        public async Task<ActionResult<ReviewReadDto>> CreateReview(int materialId, ReviewCreateDto reviewCreateDto)
        {
            var reviewModel = _mapper.Map<Review>(reviewCreateDto);
            await _reviewRepo.Add(reviewModel);
            var reviewReadDto = _mapper.Map<ReviewReadDto>(reviewModel);
            return CreatedAtRoute(nameof(GetReview), new { materialId = reviewModel.EduMaterialId, reviewId = reviewModel.Id }, reviewReadDto);
        }

        // PUT materials/{materialId}/reviews/{id}
        [HttpPut("{reviewId}")]
        public async Task<ActionResult> UpdateReview(int materialId, int reviewId, ReviewUpdateDto reviewUpdateDto)
        {
            throw new NotImplementedException();
        }

        // materials/{materialId}/reviews/{id}
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteEduMaterial(int materialId, int reviewId)
        {
            var reviewModel = await _reviewRepo.Get(reviewId);
            if (reviewModel == null)
            {
                return NotFound();
            }

            await _reviewRepo.Delete(reviewModel);
            return NoContent();
        }
    }
}
