﻿using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoleData
    {
        public Task Delete(int id);
        public Task<Role> GetById(int id);

        Task<IEnumerable<Role>> GetAll();
        public Task<Role> Save(Role entity);
        public Task<Role> Update(Role entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

    }
}
