﻿using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICountryData
    {

        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<Country> GetById(int id);
        public Task<IEnumerable<CountryDto>> GetAll();
        public Task<Country> Save(Country Country);
        public Task Update(Country Country);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
