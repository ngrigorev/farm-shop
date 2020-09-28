using System;
using System.Collections.Generic;

namespace FarmShopApp.Models
{
    public interface IDBManager
    {
        IEnumerable<Medicament> GetMedicamentList();
        IEnumerable<Category> GetCategoryList();
    }
}