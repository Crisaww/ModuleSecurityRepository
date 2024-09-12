using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class RoleData : IRoleData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RoleData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // Método para eliminar un registro de Role
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los roles con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id, 
                        CONCAT(Name, ' - ', Description, ' - ', State) AS TextoMostrar 
                    FROM 
                        Roles 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var sql = @"SELECT 
                        *
                    FROM 
                        Roles 
                    WHERE 
                        Deleted_at IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<Role>(sql);
        }

        // Método para obtener un rol por su ID
        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM Roles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }

        // Método para guardar un nuevo rol
        public async Task<Role> Save(Role entity)
        {
            context.Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un rol existente
        public async Task Update(Role entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
