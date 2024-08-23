using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IModuleData
    {

        public Task Delete(int id);
        public Task<Module> GetById(int id);
        public Task<Module> Save(Module entity);
        public Task<Module> Update(Module entity);
    }
}
