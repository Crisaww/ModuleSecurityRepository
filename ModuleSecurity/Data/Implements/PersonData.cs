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
    public class PersonData : IPersonData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public PersonData(ApplicationDbContext context, IConfiguration configuration)
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
            context.Persons.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los roles con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                Id, 
                CONCAT(First_name, ' - ', Last_name, ' - ', Phone, ' - ', Email, ' - ', Adress) AS TextoMostrar 
            FROM 
                Person 
            WHERE 
                Deleted_at IS NULL AND State = 1 
            ORDER BY 
                Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var sql = @"SELECT 
                        *
                    FROM 
                        Person 
                    WHERE 
                        Deleted_at IS NULL AND State = 1 
                    ORDER BY 
                        Id ASC";
            return await context.QueryAsync<Person>(sql);
        }

        // Método para obtener un rol por su ID
        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM Person WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }

        // Método para guardar una nueva persona
        public async Task<Person> Save(Person entity)
        {
            context.Persons.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar una persona existente
        public async Task Update(Person entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        Task<Person> IPersonData.Update(Person entity)
        {
            throw new NotImplementedException();
        }

    }
}
