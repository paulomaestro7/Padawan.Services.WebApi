using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HBSIS.Services.Util
{
    public class Result<T>
    {
        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
