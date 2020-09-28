using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FarmShopApp.Models;

namespace FarmShopApp.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IDBManager _DBManager;

        public ApiControllerBase(IDBManager DBManager)
        {
            _DBManager = DBManager;
        }

        protected APIRequest APIRequest
        {
            get 
            {
                int page = Request.Query.ContainsKey("page") && int.TryParse(Request.Query["page"], out page)
                            ? page
                            : default;

                int pageSize = Request.Query.ContainsKey("page_size") && int.TryParse(Request.Query["page_size"], out pageSize)
                            ? pageSize
                            : default;

                return new APIRequest { Page = page, PageSize = pageSize };
            }
        }
    }
}