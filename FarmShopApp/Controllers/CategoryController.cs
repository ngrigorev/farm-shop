using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FarmShopApp.Models;
using FarmShopApp.Controllers.DTO;

namespace FarmShopApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ApiControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, IDBManager DBManager)
            : base(DBManager)
        {
            _logger = logger;
        }

        [HttpGet]
        public IResponse Get()
        {
            var response = new APIResponse<IEnumerable<CategoryDTO>>();

            try
            {
                var queryParams = APIRequest;
                var categoryies = _DBManager.GetCategoryList()
                                            .Skip(queryParams.Page * queryParams.PageSize)
                                            .Take(queryParams.PageSize);

                response.Data = categoryies.Select(x => new CategoryDTO
                { 
                    Id = x.Id,
                    Name = x.Name
                });
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.IsError = true;
                response.Error = ex.Message;
            }

            return response;
        }
        

        [HttpGet]
        [Route("{idCategory}")]
        public IResponse GetCategory(string idCategory)
        {
            var response = new APIResponse<CategoryDTO>();

            try
            {
                var category = _DBManager.GetCategoryList()
                                         .SingleOrDefault(x => x.Id == idCategory);

                response.Data = new CategoryDTO
                { 
                    Id = category.Id,
                    Name = category.Name
                };
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.IsError = true;
                response.Error = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("{idCategory}/medicament")]
        public IResponse GetMedicamentListByCategory(string idCategory)
        {
            var response = new APIResponse<IEnumerable<MedicamentDTO>>();

            try
            {
                var queryParams = APIRequest;
                var category = _DBManager.GetCategoryList()
                                         .SingleOrDefault(x => x.Id == idCategory);

                var medicaments = _DBManager.GetMedicamentList()
                                            .Where(x => x.IdCategory == idCategory)
                                            .Skip(queryParams.Page * queryParams.PageSize)
                                            .Take(queryParams.PageSize);

                response.Data = medicaments.Select(x => new MedicamentDTO 
                { 
                    Id = x.Id,
                    Name = x.Name,  
                    Type = x.Type,  
                    WordName = x.WordName,  
                });
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.IsError = true;
                response.Error = ex.Message;
            }

            return response;
        }
    }
}
