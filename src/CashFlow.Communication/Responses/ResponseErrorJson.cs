using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> Errors { get; set; }

        public ResponseErrorJson(string message)
        {
            Errors = [message];
        }

        public ResponseErrorJson(List<string> errorMessages)
        {
            Errors = errorMessages;
        }

    }
}
