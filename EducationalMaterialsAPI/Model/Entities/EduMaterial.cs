namespace EducationalMaterialsAPI.Model.Entities
{
    public class EduMaterial
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int EduMaterialTypeId { get; set; }
        public EduMaterialType EduMaterialType { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
