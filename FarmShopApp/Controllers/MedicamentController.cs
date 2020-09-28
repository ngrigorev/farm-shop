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
    public class MedicamentController : ApiControllerBase
    {
        private readonly ILogger<MedicamentController> _logger;

        public MedicamentController(ILogger<MedicamentController> logger, IDBManager DBManager)
            : base(DBManager)
        {
            _logger = logger;
        }

        [HttpGet]
        public IResponse Get()
        {
            var response = new APIResponse<IEnumerable<MedicamentDTO>>();

            try
            {
                var queryParams = APIRequest;
                var medicaments = _DBManager.GetMedicamentList()
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

        [HttpGet]
        [Route("{idMedicament}")]
        public IResponse GetMedicament(string idMedicament)
        {
            var response = new APIResponse<MedicamentDTO>();

            try
            {
                var medicament = _DBManager.GetMedicamentList()
                                            .SingleOrDefault(x => x.Id == idMedicament);

                response.Data = new MedicamentDTO 
                { 
                    Id = medicament.Id,
                    Name = medicament.Name,  
                    Type = medicament.Type,  
                    WordName = medicament.WordName,  
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
    }
}
