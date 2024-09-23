using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonBusiness
    {

        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<PersonDto> GetById(int id);
        public Task<IEnumerable<PersonDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Person> Save(PersonDto entity);
        public Task Update(PersonDto entity);
    }
}
