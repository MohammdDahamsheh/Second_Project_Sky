using Domain.Entity;
using Infrastrucure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Repository.securityRepo
{
    public class RoleRepo
    {
        private readonly TenderContext context;
        public RoleRepo(TenderContext context) {
            this.context = context;
        }
        public async Task<Roles> getRoleById(int roleId) {
            var role =await context.Roles.FindAsync(roleId);
            if (role == null) { throw new Exception("No Role with this Id"); }
            return role;
        }
    }
}
