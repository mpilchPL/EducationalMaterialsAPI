using System.ComponentModel.DataAnnotations;

namespace EducationalMaterialsAPI.Data.DTOs.EduMaterialDtos
{
    public class EduMaterialCreateDto
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Description { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Location { get; set; }
        [Required]
        public int EduMaterialTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
