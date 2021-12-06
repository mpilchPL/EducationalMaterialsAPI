namespace EducationalMaterialsAPI.Model.Entities
{
    public class EduMaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public ICollection<EduMaterial>? EduMaterials { get; set; }
    }
}
