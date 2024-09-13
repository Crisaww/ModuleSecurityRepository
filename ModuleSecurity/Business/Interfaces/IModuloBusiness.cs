using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IModuloBusiness
    {
        public Task Delete(int id);
        public Task<ModuloDto> GetById(int id);
        public Task<IEnumerable<ModuloDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Modulo> Save(ModuloDto entity);
        public Task Update(ModuloDto entity);
    }
}
