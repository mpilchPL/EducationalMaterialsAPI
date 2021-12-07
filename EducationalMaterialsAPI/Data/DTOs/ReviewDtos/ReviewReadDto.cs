namespace EducationalMaterialsAPI.Data.DTOs.ReviewDtos
{
    public class ReviewReadDto
    {
        public int Id { get; set; }
        public string ReviewDescription { get; set; }
        public int ReviewPoints { get; set; }
        public int EduMaterialId { get; set; }
    }
}
