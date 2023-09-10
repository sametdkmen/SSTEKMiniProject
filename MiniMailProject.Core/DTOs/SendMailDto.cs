using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Core.DTOs
{
    public class SendMailDto
    {
        public string To { get; set; }

        public string Subject { get; set; }        

        public string Body { get; set; }

        public DateTime CreatedDate { get; set; } 
    }
}
