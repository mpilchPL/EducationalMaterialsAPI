using System.ComponentModel.DataAnnotations;

namespace EducationalMaterialsAPI.Data.DTOs.EduMaterialTypeDtos
{
    public class EduMaterialTypeCreateDto
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Definition { get; set; }
    }
}
