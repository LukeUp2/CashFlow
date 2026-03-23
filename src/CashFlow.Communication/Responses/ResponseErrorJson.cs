using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public string ErrorMessage { get; set; } = string.Empty;

        public ResponseErrorJson(string message)
        {
            ErrorMessage = message;
        }
    }
}