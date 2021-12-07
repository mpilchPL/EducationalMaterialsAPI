using System.ComponentModel.DataAnnotations;

namespace EducationalMaterialsAPI.Data.DTOs.EduMaterialDtos
{
    public class EduMaterialCreateDto
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int EduMaterialTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
