﻿using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class ViewBusiness : IViewBusiness
    {
        protected readonly IViewData data;

        public ViewBusiness(IViewData data)
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

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            IEnumerable<ViewDto> views = await this.data.GetAll();
            //var viewDtos = views.Select(view => new ViewDto
            //{
            //    Id = view.Id,
            //    Name = view.Name,
            //    Description = view.Description,
            //    Route = view.Route,
            //    ModuloId = view.ModuloId,
            //    State = view.State
            //});

            return views;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {

            return await this.data.GetAllSelect();
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await this.data.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.Name = view.Name;
            viewDto.Description = view.Description;
            viewDto.Route = view.Route;
            viewDto.ModuloId = view.ModuloId;
            viewDto.State = view.State;
            return viewDto;
        }

           

        public View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Name = entity.Name;
            view.Description = entity.Description;
            view.Route = entity.Route;
            view.ModuloId = entity.ModuloId; 
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
            //view.Module = null;
            return await this.data.Save(view);
        }

        public async Task Update(ViewDto entity)
        {
            View view = await this.data.GetById(entity.Id);
            view.UpdateAt = DateTime.Now.AddHours(-5);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.mapearDatos(view, entity);
            await this.data.Update(view);
        }
    }
}
