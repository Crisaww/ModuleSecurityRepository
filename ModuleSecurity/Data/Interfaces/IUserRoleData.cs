using Entity.DTO;
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
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<UserRole> GetById(int id);
        public Task<IEnumerable<UserRoleDto>> GetAll();
        public Task<UserRole> Save(UserRole UserRole);
        public Task Update(UserRole UserRole);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
