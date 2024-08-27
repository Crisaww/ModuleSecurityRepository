using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IViewBusiness
    {
        public Task Delete(int id);
        public Task<ViewDto> GetById(int id);
        public Task<IEnumerable<ViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<View> Save(ViewDto entity);
        public Task Update(ViewDto entity);
    }
}
