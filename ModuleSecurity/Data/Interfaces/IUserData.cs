using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserData
    {

        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<User> GetById(int id);
        public Task<IEnumerable<UserDto>> GetAll();
        public Task<User> Save(User User);
        public Task Update(User User);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
