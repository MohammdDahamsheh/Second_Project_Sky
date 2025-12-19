using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.security
{
    public class JWTSitting
    {
        public JWTSitting() { }
        public string issuer { get; set; }
        public string audience { get; set; }
        public string key { get; set; }
        public int expMinutes { get; set; }
    }
}
