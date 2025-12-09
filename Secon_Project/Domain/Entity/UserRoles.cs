using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserRoles
    {
        public int userId { get; set; }
        public Users user { get; set; }
        public int roleId { get; set; }
        public Roles role { get; set; }


        public UserRoles(int userId, int roleId)
        {
            this.userId = userId;
            this.roleId = roleId;
        }


    }
}
