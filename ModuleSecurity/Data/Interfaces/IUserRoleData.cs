using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRoleData
    {
        //public async Task<Role> GetByName (string name)
        //{
        //    return await this.context.Roles.AsNoTracking().Where(item => item.Name = = name).FirstOrDefaultAsync();
        //}

        public Task Delete(int id);
        public Task<UserRole> GetById(int id);
        public Task<UserRole> Save(UserRole entity);
        public Task<UserRole> Update(UserRole entity);
    }
}
