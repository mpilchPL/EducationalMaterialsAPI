namespace EducationalMaterialsAPI.Model.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewDescription { get; set; }
        public int ReviewPoints { get; set; }
        public int EduMaterialId { get; set; }
        public EduMaterial EduMaterial { get; set; }
    }
}
