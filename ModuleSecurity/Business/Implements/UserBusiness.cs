using Business.Interfaces;
using Data.Implements;
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
    public class UserBusiness : IUserBusiness
    {
        protected readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserDto> users = await this.data.GetAll();
            //var userDtos = users.Select(user => new UserDto
            //{
            //    Id = user.Id,
            //    Username = user.Username,
            //    Password = user.Password,
            //    PersonId = user.PersonId,
            //    State = user.State
            //});

            return users;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await this.data.GetById(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.Username = user.Username;
            userDto.Password = user.Password;
            userDto.PersonId = user.PersonId;
            userDto.State = user.State;

            return userDto;
        }

        public User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.PersonId = entity.PersonId;
            user.State = entity.State;
            return user;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            user = this.mapearDatos(user, entity);
            return await this.data.Save(user);
        }

        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            user.UpdateAt = DateTime.Now.AddHours(-5);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.mapearDatos(user, entity);
            await this.data.Update(user);
        }
    }

}
