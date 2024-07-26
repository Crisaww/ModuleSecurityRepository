using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    internal interface IUserRoleData
    {
        public async Task<Role> GetByName (string name)
        {
            return await this.context.Roles.AsNoTracking().Where(item => item.Name = = name).FirstOrDefaultAsync();
        }
    }
}
