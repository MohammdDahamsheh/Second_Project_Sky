using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.security
{
    public class JWTResponse
    {
        public JWTResponse() { }
        public string token { get; set; }
        public DateTime ExpiresAuth { get; set; }
    }
}
