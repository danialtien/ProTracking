using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.CustomDomain
{
    public class ReponseMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Content { get; set; }
    }
}
