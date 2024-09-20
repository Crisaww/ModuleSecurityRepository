﻿using Data.Interfaces;
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
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UserRoleData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // Método para eliminar un registro de UserRol
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.UserRoles.Update(entity);
            await context.SaveChangesAsync();
        }

        // Método para obtener todos los UserRols con un formato específico
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                    Id, 
                    CONCAT(UserId, ' - ', RoleId, ' - ', State) AS TextoMostrar 
                FROM 
                    userroles 
                WHERE 
                    DeleteAt IS NULL AND State = 1 
                ORDER BY 
                    Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            var sql = @"SELECT
                        	ur.Id,
                            ur.UserId,
                            ur.RoleId,
                            us.Username AS NameUser,
                            ro.Name AS NameRole

                            FROM userroles AS ur

                            INNER JOIN users AS us ON us.Id = ur.UserId
                            INNER JOIN roles AS ro ON ro.Id = ur.RoleId";
            return await context.QueryAsync<UserRoleDto>(sql);
        }

        // Método para obtener un UserRol por su ID
        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM userroles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<UserRole>(sql, new { Id = id });
        }

        // Método para guardar un nuevo UserRol
        public async Task<UserRole> Save(UserRole entity)
        {
            context.UserRoles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        // Método para actualizar un UserRol existente
        public async Task Update(UserRole entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

}
