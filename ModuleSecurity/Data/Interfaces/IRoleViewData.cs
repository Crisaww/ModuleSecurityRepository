using Entity.DTO;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        public Task Delete(int id);
        public Task<RoleView> GetById(int id);
        public Task<IEnumerable<RoleView>> GetAll();
        public Task<RoleView> Save(RoleView RoleView);
        public Task Update(RoleView RoleView);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
