namespace EducationalMaterialsAPI.Model.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EduMaterial> EduMaterials { get; set; }
        public int TotalEduMaterials { get => EduMaterials == null ? 0 : EduMaterials.Count; }

    }
}
