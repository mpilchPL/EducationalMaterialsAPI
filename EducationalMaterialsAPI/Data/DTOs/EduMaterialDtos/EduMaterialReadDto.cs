using System.ComponentModel.DataAnnotations;

namespace EducationalMaterialsAPI.Data.DTOs.EduMaterialDtos
{
    public class EduMaterialReadDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Location { get; set; }
        public int EduMaterialTypeId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime PublishDate { get; set; }
    }
}
