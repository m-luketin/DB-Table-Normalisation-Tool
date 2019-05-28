using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Normalization.Maps;
using Normalization.Maps.Algorithm;
using Normalization.ViewModel;

namespace Normalization.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AnyOrigin")]
    public class NormalizationController : Controller
    {
        [HttpGet("{id}")]
        public NormalizedViewModel Generate(int id)
        {
            var tableMap = new TableMap();
            var tableViewModel = tableMap.ReadFromId(id);
            return Algorithm.NormalizeTable(((TableViewModel)tableViewModel));
        }
    }
}