using BrainCode.Api.Models;
using BrainCode.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Helpers
{
    public class BearerHelper
    {
        private static BearerService _bearerService;

        private static Header _bearerHeader;

        static BearerHelper()
        {
            _bearerService = new BearerService();
        }

        public async static Task<Header> GetBearerHeader()
        {
            if(_bearerHeader == null)
            {
                _bearerHeader = await       _bearerService.GetBearerHeader();
            }
            return _bearerHeader;
        }

        public async static Task Renew()
        {
            _bearerHeader = await _bearerService.GetBearerHeader();
        }
    }
}
