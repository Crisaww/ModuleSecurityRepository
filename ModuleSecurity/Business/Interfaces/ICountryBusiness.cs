using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICountryBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<CountryDto> GetById(int id);
        public Task<IEnumerable<CountryDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Country> Save(CountryDto entity);
        public Task Update(CountryDto entity);
    }
}
