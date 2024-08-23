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
    public class ViewRolData : IViewData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ViewRolData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // Método para eliminar un registro de ViewRol
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los ViewRols con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id, 
                CONCAT(Name, ' - ', Description) AS TextoMostrar 
            FROM 
                View
            WHERE 
                Deleted_at IS NULL AND State = 1 
            ORDER BY 
                Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        // Método para obtener un ViewRol por su ID
        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM View WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }

        // Método para guardar un nuevo ViewRol
        public async Task<View> Save(View entity)
        {
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un View existente
        public async Task Update(View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<View> IViewData.Update(View entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<View>> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
