using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberis.DueDil.Sdk.Responses
{
    public class DueDilClientResponse<T>
    {
        public T Data { get; set; }

        public bool IsOk { get; set; }
    }
}
