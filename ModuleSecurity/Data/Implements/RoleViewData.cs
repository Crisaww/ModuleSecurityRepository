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
    public class RoleViewData : IRoleViewData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RoleViewData(ApplicationDbContext context, IConfiguration configuration)
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
            context.RoleViews.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los roles con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id, 
                CONCAT(State, ' - ', RoleId, ' - ', ViewId, ' - ' Role, ' - ', View) AS TextoMostrar 
            FROM 
                roleViews 
            WHERE 
                DeleteAt IS NULL AND State = 1 
            ORDER BY 
                Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<RoleView>> GetAll()
        {
            var sql = @"SELECT 
                *
            FROM 
                roleViews
            WHERE 
                DeleteAt IS NULL AND State = 1 
            ORDER BY 
                Id ASC";
            return await context.QueryAsync<RoleView>(sql);
        }

        // Método para obtener un rol por su ID
        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM roleViews WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }

        // Método para guardar un nuevo RoleView
        public async Task<RoleView> Save(RoleView entity)
        {
            context.RoleViews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un RoleView existente
        public async Task Update(RoleView entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<RoleView> IRoleViewData.Update(RoleView entity)
        {
            throw new NotImplementedException();
        }
    }
}
