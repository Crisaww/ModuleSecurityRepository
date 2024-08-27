using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleBusiness
    {
        public Task Delete(int id);
        public Task<RoleDto> GetById(int id);
        public Task<IEnumerable<RoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Role> Save(RoleDto entity);
        public Task Update(RoleDto entity);
    }
}
