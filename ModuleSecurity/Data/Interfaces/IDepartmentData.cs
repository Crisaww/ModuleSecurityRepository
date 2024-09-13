using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IDepartmentData
    {

        public Task Delete(int id);
        public Task<Department> GetById(int id);
        public Task<IEnumerable<Department>> GetAll();
        public Task<Department> Save(Department State);
        public Task Update(Department State);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
