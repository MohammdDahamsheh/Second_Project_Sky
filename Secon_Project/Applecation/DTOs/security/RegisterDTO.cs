using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.DTOs.security
{
    public class RegisterDTO
    {
        public string username {  get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int roleId { get; set; }

        public RegisterDTO() { }
    }
}
