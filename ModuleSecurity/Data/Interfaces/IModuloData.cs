using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModuloData
    {

        public Task Delete(int id);
        public Task<Modulo> GetById(int id);
        public Task<IEnumerable<Modulo>> GetAll();
        public Task<Modulo> Save(Modulo Modulo);
        public Task Update(Modulo Modulo);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
