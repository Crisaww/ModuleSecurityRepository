using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserRoleBusiness
    {

        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<UserRoleDto> GetById(int id);
        public Task<IEnumerable<UserRoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<UserRole> Save(UserRoleDto entity);
        public Task Update(UserRoleDto entity);
    }
}
