using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HBSIS.Services.Model.Util
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
