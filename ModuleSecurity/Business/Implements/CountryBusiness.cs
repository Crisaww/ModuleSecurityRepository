using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class CountryBusiness : ICountryBusiness
    {
        protected readonly ICountryData data;

        public CountryBusiness(ICountryData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            IEnumerable<Country> countries = await this.data.GetAll();
            var countryDtos = countries.Select(country => new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                Capital = country.Capital
            });

            return countryDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<CountryDto> GetById(int id)
        {
            Country country = await this.data.GetById(id);
            CountryDto countryDto = new CountryDto();

            countryDto.Id = country.Id;
            countryDto.Name = country.Name;
            countryDto.Capital = country.Capital;

            return countryDto;
        }

        public Country mapearDatos(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.Name = entity.Name;
            country.Capital = entity.Capital;
            return country;
        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            country = this.mapearDatos(country, entity);
            return await this.data.Save(country);
        }

        public async Task Update(CountryDto entity)
        {
            Country country = await this.data.GetById(entity.Id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = this.mapearDatos(country, entity);
            await this.data.Update(country);
        }
    }

}
