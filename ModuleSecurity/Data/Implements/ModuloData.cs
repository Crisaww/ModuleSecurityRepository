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
    public class ModuloData : IModuloData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDbContext context, IConfiguration configuration)
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
            context.Modulos.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los roles con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id, 
                        CONCAT(Description, ' - ', State) AS TextoMostrar 
                    FROM 
                        modulos 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<Modulo>> GetAll()
        {
            var sql = @"SELECT 
                        *
                    FROM 
                        modulos 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<Modulo>(sql);
        }

        // Método para obtener un rol por su ID
        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM modulos WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }

        // Método para guardar un nuevo rol
        public async Task<Modulo> Save(Modulo entity)
        {
            context.Modulos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un rol existente
        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
