using System.ComponentModel.DataAnnotations;

namespace EducationalMaterialsAPI.Data.DTOs.AuthorDtos
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Description { get; set; }
    }
}
