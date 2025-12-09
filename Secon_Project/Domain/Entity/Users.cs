using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Users
    {
        [Key]
        public int userId { get; private set; }
        public string userName { get; private set; }
        public string userPassword { get; private set; }

        public ICollection<UserRoles> userRoles { get; set; }

        public ICollection<Tender> tenders { get; set; }
        public Users( string ?userName, string ?userPassword)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            

        }
    }
}
