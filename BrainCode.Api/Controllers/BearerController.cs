using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainCode.Api.Models;
using BrainCode.Api.Services;
using BrainCode.Api.Helpers;
using Microsoft.AspNetCore.Cors;

namespace BrainCode.Api.Controllers
{
    [Route("api/Bearer")]
    [EnableCors("AllowAllOrigin")]
    public class BearerController : Controller
    {
        [HttpGet()]
        public async Task<string> Get(string id)
        {
            return (await BearerHelper.GetBearerHeader()).Value;
        }
    }
}
