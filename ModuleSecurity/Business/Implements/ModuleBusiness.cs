using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ModuleBusiness
    {
        protected readonly IModuleData data;

        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            IEnumerable<View> views = await this.data.GetAll();

            var viewDtos = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                Route = view.Route,
                ModuleId = view.ModuleId,
                State = view.State
            });

            return viewDtos;
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.data.GetById(id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }

            ViewDto viewDto = new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                Route = view.Route,
                ModuleId = view.ModuleId,
                State = view.State
            };

            return viewDto;
        }

        public View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Name = entity.Name;
            view.Description = entity.Description;
            view.Route = entity.Route;
            view.ModuleId = entity.ModuleId;
            view.State = entity.State;
            return view;
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            view = this.mapearDatos(view, entity);
            view.Module = null;
            return await this.data.Save(view);
        }

        public async Task Update(ViewDto entity)
        {
            View view = await this.data.GetById(entity.Id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.mapearDatos(view, entity);
            await this.data.Update(view);
        }

        Task<ViewDto> IViewBusiness.Save(ViewDto entity)
        {
            throw new NotImplementedException();
        }

        Task<ViewDto> IViewBusiness.Update(ViewDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
