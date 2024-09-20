using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IViewData
    {
        public Task Delete(int id);
        public Task<View> GetById(int id);
        public Task<IEnumerable<ViewDto>> GetAll();
        public Task<View> Save(View View);
        public Task Update(View View);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
