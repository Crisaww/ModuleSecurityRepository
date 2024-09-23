using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRoleViewBusiness
    {

        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<RoleViewDto> GetById(int id);
        public Task<IEnumerable<RoleViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleView> Save(RoleViewDto entity);
        public Task Update(RoleViewDto entity);
    }
}
