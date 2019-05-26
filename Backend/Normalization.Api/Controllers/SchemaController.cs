using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Normalization.Maps;
using Normalization.ViewModel;

namespace Normalization.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AnyOrigin")]
    public class SchemaController : Controller
    {
        [HttpGet]
        public ICollection<IViewModel> Get()
        {
            return new TableMap().Read();
        }

        [HttpGet("{id}")]
        public IViewModel Get(int id)
        {
            return new TableMap().ReadFromId(id);
        }
        [HttpPost]
        public IViewModel Post(TableViewModel tableView)
        {
            return new TableMap().Create(tableView);
        }
    }
}