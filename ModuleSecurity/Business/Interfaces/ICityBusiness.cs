using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICityBusiness
    {
        public Task Delete(int id);
        public Task<CityDto> GetById(int id);
        public Task<IEnumerable<CityDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<City> Save(CityDto entity);
        public Task Update(CityDto entity);
    }
}
