using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new TableMap().Delete(id);
        }

        [HttpPut]
        public TableViewModel Update(TableViewModel tableView)
        {
           return (TableViewModel) new TableMap().Update(tableView);
        }
    }
}