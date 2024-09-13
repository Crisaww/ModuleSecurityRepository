using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class CityData : ICityData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // Método para eliminar un registro de City
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Cities.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todas las ciudades con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id, 
                        CONCAT(Name, ' - ', Population, ' - ', DepartmentId, ' - ', YearFundation) AS TextoMostrar 
                    FROM 
                        cities 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var sql = @"SELECT
                        	ci.Id,
	                        ci.Name,
                            ci.population,
                            ci.DepartmentId,
                            de.Name AS Department

                            FROM cities AS ci
                            INNER JOIN departments AS de ON de.Id = ci.DepartmentId";
            return await context.QueryAsync<CityDto>(sql);
        }

        // Método para obtener una ciudad por su ID
        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM cities WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        // Método para guardar una nueva ciudad
        public async Task<City> Save(City entity)
        {
            context.Cities.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar una ciudad existente
        public async Task Update(City entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
