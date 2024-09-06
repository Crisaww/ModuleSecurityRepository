using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStateBusiness
    {
        public Task Delete(int id);
        public Task<StateDto> GetById(int id);
        public Task<IEnumerable<StateDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<State> Save(StateDto entity);
        public Task Update(StateDto entity);
    }
}
