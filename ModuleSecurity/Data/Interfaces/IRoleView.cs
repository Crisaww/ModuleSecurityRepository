using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleView
    {
        public Task Delete(int id);
        public Task<RoleView> GetById(int id);
        public Task<RoleView> Save(RoleView entity);
        public Task<RoleView> Update(RoleView entity);
    }
}
