using Domain.Entity.Bids;
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
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public ICollection<UserRoles> userRoles { get; set; }

        public ICollection<Tender> tenders { get; set; }
        public IEnumerable<Bid> bids { get; set; }
        public Users( string userName, string userPassword,string email,string phoneNumber)
        {
            this.userName = userName;
            this.userPassword = userPassword;
            this.email= email;
            this.phoneNumber= phoneNumber;
        }
    }
}
