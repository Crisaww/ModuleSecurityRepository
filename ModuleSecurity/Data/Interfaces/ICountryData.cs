using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountryData
    {

        public Task Delete(int id);
        public Task<Country> GetById(int id);
        public Task<IEnumerable<Country>> GetAll();
        public Task<Country> Save(Country entity);
        public Task<Country> Update(Country entity);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
