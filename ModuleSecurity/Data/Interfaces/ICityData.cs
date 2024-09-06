using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICityData
    {

        public Task Delete(int id);
        public Task<City> GetById(int id);
        public Task<IEnumerable<City>> GetAll();
        public Task<City> Save(City entity);
        public Task<City> Update(City entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
