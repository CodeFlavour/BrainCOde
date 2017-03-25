using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Models.Analyze
{
    public class ResultToken
    {
        public string Text { get; set; }
        public int Views { get; set; }
        public int Occurences { get; set; }
        public int Stat
        {
            get
            {
                return (int) Views;
            }
        }
    }
}
