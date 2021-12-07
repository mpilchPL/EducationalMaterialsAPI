namespace EducationalMaterialsAPI.Data.DTOs.ReviewDtos
{
    public class ReviewCreateDto
    {
        public string ReviewDescription { get; set; }
        public int ReviewPoints { get; set; }
        public int EduMaterialId { get; set; }
    }
}
