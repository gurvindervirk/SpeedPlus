using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaBusinessLayer
{
    public class ValidationException : Exception
    {
        public int Code { get; private set; }
        public ValidationException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
