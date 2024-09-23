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
    public class ViewData : IViewData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ViewData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Views.Remove(entity);
            await context.SaveChangesAsync();
        }

        // Método para eliminar un registro de ViewRol
        public async Task LogicalDelete(int Id)
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
                CONCAT(Name, ' - ', Description, ' - ', State, ' - ', Route, ' - ', ModuloId) AS TextoMostrar 
            FROM 
                views
            WHERE 
                DeletedAt IS NULL AND State = 1 
            ORDER BY 
                Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            var sql = @"SELECT
			                vi.Id,
			                vi.Name,
			                vi.Description,
			                vi.State,
			                vi.Route,
			                vi.ModuloId,
			                mo.Description AS DescripModulo

			                FROM views AS vi
			                INNER JOIN modulos AS mo ON mo.Id = vi.ModuloId
			                WHERE ISNULL(vi.DeleteAt)";
            return await context.QueryAsync<ViewDto>(sql);
        }

        // Método para obtener un ViewRol por su ID
        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM views WHERE Id = @Id ORDER BY Id ASC";
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
    }

}
