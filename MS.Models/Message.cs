using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }

    }
}
