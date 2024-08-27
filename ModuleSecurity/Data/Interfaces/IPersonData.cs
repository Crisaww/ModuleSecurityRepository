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
        public Task<Person> GetById(int id);
        public Task<IEnumerable<Person>> GetAll();
        public Task<Person> Save(Person entity);
        public Task<Person> Update(Person entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

    }
}
