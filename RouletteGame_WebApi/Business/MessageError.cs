using RouletteGame_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteGame_WebApi.Business
{
    public class MessageError
    {
        public RequestResponse MapResponseError(string message)
        {
            return new RequestResponse
            {
                SuccessFul = false,
                MessageError = (string.IsNullOrEmpty(message) ? string.Empty : message)
            };
        }
    }
}
