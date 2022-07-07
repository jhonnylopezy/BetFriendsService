using System;
using System.Collections.Generic;
using System.Text;

namespace BF.Domain.Model

{
    public class RespuestaModel <T>
    {

        public string errCode { get; set; }
        public string errMessage { get; set; }
        public T data { get; set; }
    }
}
