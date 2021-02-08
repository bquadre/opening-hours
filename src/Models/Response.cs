using System;
using System.Collections.Generic;

namespace OpeningHours.API.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Data { get; set; }
    }
}
