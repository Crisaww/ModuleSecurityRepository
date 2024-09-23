using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
        protected readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
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

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRoleDto> userroles = await this.data.GetAll();
            //var userroleDtos = userroles.Select(userrole => new UserRoleDto
            //{
            //    Id = userrole.Id,
            //    RoleId = userrole.RoleId,
            //    UserId = userrole.UserId,
            //    State = userrole.State
            //});

            return userroles;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userrole = await this.data.GetById(id);
            UserRoleDto userroleDto = new UserRoleDto();

            userroleDto.Id = userrole.Id;
            userroleDto.RoleId = userrole.RoleId;
            userroleDto.UserId = userrole.UserId;
            userroleDto.State = userrole.State;

            return userroleDto;
        }

        public UserRole mapearDatos(UserRole userrole, UserRoleDto entity)
        {
            userrole.Id = entity.Id;
            userrole.RoleId = entity.RoleId;
            userrole.UserId = entity.UserId;
            userrole.State = entity.State;
            return userrole;
        }

        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userrole = new UserRole
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            userrole = this.mapearDatos(userrole, entity);
            //userrole.UserRole = null;
            return await this.data.Save(userrole);
        }

        public async Task Update(UserRoleDto entity)
        {
            UserRole userrole = await this.data.GetById(entity.Id);
            userrole.UpdateAt = DateTime.Now.AddHours(-5);
            if (userrole == null)
            {
                throw new Exception("Registro no encontrado");
            }
            userrole = this.mapearDatos(userrole, entity);
            await this.data.Update(userrole);
        }
    }

}
