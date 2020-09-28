namespace FarmShopApp.Controllers.DTO
{
    public class MedicamentDTO
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string WordName { get; set; }

        public string Type { get; set; }
    }
    
    public class MedicamentExtendedDTO : MedicamentDTO
    {
        public CategoryDTO Category { get; set; }
    }
}