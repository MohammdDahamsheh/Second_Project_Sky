using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Response
{
    public class ForgetPasswordResponse
    {
        public ForgetPasswordResponse()
        {
        }

        public string email { get; set; }
        public string resetToken { get; set; }

    }
}
