using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainCode.Api.Models;
using BrainCode.Api.Services;
using BrainCode.Api.Helpers;
using BrainCode.Api.Models.Analyze;
using Microsoft.AspNetCore.Cors;

namespace BrainCode.Api.Controllers
{
    [Route("api/Statistics")]
    [EnableCors("AllowAllOrigin")]
    public class StatisticsController : Controller
    {
        private AnalyzeService _analyzeService;

        public StatisticsController()
        {
            _analyzeService = new AnalyzeService();
        }

        [HttpGet()]
        public async Task<List<ResultToken>> Get(string phrase, decimal priceFrom, decimal priceTo)
        {
            return await _analyzeService.Analyze(phrase, priceFrom, priceTo);
        }
    }
}
