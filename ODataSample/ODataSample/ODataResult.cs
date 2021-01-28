using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataSample
{
    public class ODataResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public long? Count { get; set; }
    }
}
