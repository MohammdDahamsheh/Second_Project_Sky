using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs.security
{
    public class restPasswordDTO
    {
        public restPasswordDTO()
        {
        }
        public string email { get; set; }
        public string Password { get; set; }
        public string token { get; set; }


       
    }
}
