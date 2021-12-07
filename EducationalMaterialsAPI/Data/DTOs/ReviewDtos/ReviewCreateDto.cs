using System.ComponentModel.DataAnnotations;

namespace EducationalMaterialsAPI.Data.DTOs.ReviewDtos
{
    public class ReviewCreateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string ReviewDescription { get; set; }
        [Required]
        [Range(1, 10)]
        public int ReviewPoints { get; set; }
        [Required]
        public int EduMaterialId { get; set; }
    }
}
