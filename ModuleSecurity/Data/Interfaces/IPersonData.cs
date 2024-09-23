using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPersonData
    {

        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<Person> GetById(int id);
        public Task<IEnumerable<PersonDto>> GetAll();
        public Task<Person> Save(Person Person);
        public Task Update(Person Person);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

    }
}
