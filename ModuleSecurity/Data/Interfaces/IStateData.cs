using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IStateData
    {

        public Task Delete(int id);
        public Task<State> GetById(int id);
        public Task<IEnumerable<State>> GetAll();
        public Task<State> Save(State entity);
        public Task<State> Update(State entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
