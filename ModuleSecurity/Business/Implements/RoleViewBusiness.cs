using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class RoleViewBusiness : IRoleViewBusiness
    {
        protected readonly IRoleViewData data;

        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task LogicalDelete(int id)
        {
            await this.data.LogicalDelete(id);
        }

        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleView> roleviews = await this.data.GetAll();
            var roleviewDtos = roleviews.Select(roleview => new RoleViewDto
            {
                Id = roleview.Id,
                RoleId = roleview.RoleId,
                ViewId = roleview.ViewId,
               
                State = roleview.State
            });

            return roleviewDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<RoleViewDto> GetById(int id)
        {
            RoleView roleview = await this.data.GetById(id);
            RoleViewDto roleviewDto = new RoleViewDto();

            roleviewDto.Id = roleview.Id;
            roleviewDto.RoleId = roleview.RoleId;
            roleviewDto.ViewId = roleview.ViewId;
          
            roleviewDto.State = roleview.State;

            return roleviewDto;
        }

        public RoleView mapearDatos(RoleView roleview, RoleViewDto entity)
        {
            roleview.Id = entity.Id;
            roleview.RoleId = entity.RoleId;
            roleview.ViewId = entity.ViewId;
            
            roleview.State = entity.State;
            return roleview;
        }

        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleview = new RoleView
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };

            roleview = this.mapearDatos(roleview, entity);
            return await this.data.Save(roleview);
        }

        public async Task Update(RoleViewDto entity)
        {
            RoleView roleview = await this.data.GetById(entity.Id);

            roleview.UpdateAt = DateTime.Now.AddHours(-5);


            if (roleview == null)
            {
                throw new Exception("Registro no encontrado");
            }

            roleview = this.mapearDatos(roleview, entity);
            await this.data.Update(roleview);
        }
    }

}
