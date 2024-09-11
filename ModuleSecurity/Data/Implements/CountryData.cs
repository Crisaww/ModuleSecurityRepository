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
    public class CountryData : ICountryData
    {

        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CountryData(ApplicationDbContext context, IConfiguration configuration)
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
            context.Countries.Remove(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todosa los roles con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id, 
                        CONCAT(Name, ' - ', Population, ' - ', Capital, ' - ', Coin, ' - ', Official_language) AS TextoMostrar 
                    FROM 
                        countries 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            var sql = @"SELECT 
                        *
                    FROM 
                        countries 
                    WHERE 
                        DeleteAt IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<Country>(sql);
        }

        // Método para obtener un rol por su ID
        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM countries WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        // Método para guardar un nuevo rol
        public async Task<Country> Save(Country entity)
        {
            context.Countries.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un rol existente
        public async Task Update(Country entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
