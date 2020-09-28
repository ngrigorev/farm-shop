using System.Collections.Generic;

namespace FarmShopApp.Controllers.DTO
{
    public class CategoryDTO
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
    }
    
    public class CategoryExtendedDTO : CategoryDTO
    {
        public IEnumerable<MedicamentDTO> MedicamentList { get; set; }
    }
}