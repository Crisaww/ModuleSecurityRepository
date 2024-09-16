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
    public class DepartmentData : IDepartmentData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public DepartmentData(ApplicationDbContext context, IConfiguration configuration)
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
            context.Departments.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los estados con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id, 
                        CONCAT(Name, ' - ', Population, ' - ' Capital, ' - ' CountryId) AS TextoMostrar 
                    FROM 
                        departments 
                    WHERE 
                        DeleteAt IS NULL AND States = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            var sql = @"SELECT
                        	depa.Id,
	                        depa.Name,
                            depa.population,
                            depa.Capital,
                            depa.CountryId,
                            cou.Name AS Country

                            FROM departments AS depa
                            INNER JOIN countries AS cou ON cou.Id = depa.CountryId";
            return await context.QueryAsync<DepartmentDto>(sql);
        }

        // Método para obtener un estado por su ID
        public async Task<Department> GetById(int id)
        {
            var sql = @"SELECT * FROM departments WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Department>(sql, new { Id = id });
        }

        // Método para guardar un nuevo estado
        public async Task<Department> Save(Department entity)
        {
            context.Departments.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un estado existente
        public async Task Update(Department entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

}
