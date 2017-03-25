using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainCode.Api.Models;
using BrainCode.Api.Services;
using Microsoft.AspNetCore.Cors;

namespace BrainCode.Api.Controllers
{
    [Route("api/OfferDetails")]
    [EnableCors("AllowAllOrigin")]
    public class OfferDetailsController : Controller
    {
        private OfferDetailsService _offerDetailsService;

        public OfferDetailsController()
        {
            _offerDetailsService = new OfferDetailsService();
        }

        [HttpGet("{id}")]
        public async Task<OfferDetails> Get(string id)
        {
            return await _offerDetailsService.GetOfferDetails(id);
        }
    }
}
