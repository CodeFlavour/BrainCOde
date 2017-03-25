using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainCode.Api.Models
{
    public class FilterDescriptor
    {
        public FilterDescriptor()
        {
            Values = new List<FilterDescriptorValues>();
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public List<FilterDescriptorValues> Values { get; set; }
    }

    public class FilterDescriptorValues
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
