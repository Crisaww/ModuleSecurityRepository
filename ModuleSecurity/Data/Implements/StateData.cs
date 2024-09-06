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
    public class StateData : IStateData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public StateData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // Método para eliminar un registro de State
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.States.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los estados con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id, 
                        CONCAT(Name, ' - ', Capital) AS TextoMostrar 
                    FROM 
                        State 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            var sql = @"SELECT 
                        *
                    FROM 
                        State 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<State>(sql);
        }

        // Método para obtener un estado por su ID
        public async Task<State> GetById(int id)
        {
            var sql = @"SELECT * FROM State WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<State>(sql, new { Id = id });
        }

        // Método para guardar un nuevo estado
        public async Task<State> Save(State entity)
        {
            context.States.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un estado existente
        public async Task Update(State entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<State> IStateData.Update(State entity)
        {
            throw new NotImplementedException();
        }
    }

}
