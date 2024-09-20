
using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UserData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // Método para eliminar un registro de User
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los usuarios con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                    Id, 
                    CONCAT(Username, ' - ', Password, ' - ', PersonId, ' - ', State) AS TextoMostrar 
                FROM 
                    users 
                WHERE 
                    DeleteAt IS NULL AND State = 1 
                ORDER BY 
                    Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var sql = @"SELECT
                        	us.Id,
	                        us.Username,
                            us.Password,
                            us.State,
                            us.PersonId,
                            per.first_name AS NamePerson

                            FROM users AS us
                            INNER JOIN persons AS per ON per.Id = us.PersonId";
            return await context.QueryAsync<UserDto>(sql);
        }

        // Método para obtener un usuario por su ID
        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM users WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        // Método para guardar un nuevo usuario
        public async Task<User> Save(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un usuario existente
        public async Task Update(User entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();

        }
    }
}
