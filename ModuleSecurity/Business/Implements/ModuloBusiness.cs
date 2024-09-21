﻿using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ModuloBusiness : IModuloBusiness
    {
        protected readonly IModuloData data;

        public ModuloBusiness(IModuloData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            IEnumerable<ModuloDto> modulos = await this.data.GetAll();
            //var modulosDtos = modulos.Select(module => new ModuloDto
            //{
            //    Id = module.Id,
            //    Description = module.Description,
            //    State = module.State
            //});

            return modulos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo modulo = await this.data.GetById(id);
            ModuloDto moduloDto = new ModuloDto();

            moduloDto.Id = modulo.Id;

            moduloDto.Description = modulo.Description;

            moduloDto.State = modulo.State;

            return moduloDto;
        }



        public Modulo mapearDatos(Modulo modulo, ModuloDto entity)
        {
            modulo.Id = entity.Id;
            modulo.Description = entity.Description;
            modulo.State = entity.State;
            return modulo;
        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            modulo = this.mapearDatos(modulo, entity);
            //module.Module = null;
            return await this.data.Save(modulo);
        }

        public async Task Update(ModuloDto entity)
        {
            Modulo modulo = await this.data.GetById(entity.Id);
            modulo.UpdateAt = DateTime.Now.AddHours(-5);
            if (modulo == null)
            {
                throw new Exception("Registro no encontrado");
            }
            modulo = this.mapearDatos(modulo, entity);
            await this.data.Update(modulo);
        }
    }
}
