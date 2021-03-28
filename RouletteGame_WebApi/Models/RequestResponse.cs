using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Models
{
    public class RequestResponse
    {
        public bool SuccessFul { get; set; }
        public string MessageError { get; set; }
        public string MessageSuccess { get; set; }
    }
}
