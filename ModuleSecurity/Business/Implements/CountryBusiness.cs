using Business.Interfaces;
using Data.Implements;
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

        public async Task LogicalDelete(int id)
        {
            await this.data.LogicalDelete(id);
        }


        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            IEnumerable<CountryDto> countries = await this.data.GetAll();
            //var countryDtos = countries.Select(country => new CountryDto
            //{
            //    Id = country.Id,
            //    Name = country.Name,
            //    Population = country.Population,
            //    Capital = country.Capital,
            //    Coin = country.Coin,
            //    Official_language = country.Official_language
            //});

            return countries;
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
            countryDto.Population = country.Population;
            countryDto.Capital = country.Capital;
            countryDto.Coin = country.Coin;
            countryDto.Official_language = country.Official_language;
            countryDto.State = country.State;

            return countryDto;
        }

        public Country mapearDatos(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.Name = entity.Name;
            country.Population = entity.Population;
            country.Capital = entity.Capital;
            country.Coin = entity.Coin;
            country.Official_language = entity.Official_language;
            country.State = entity.State;
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
            country.UpdateAt = DateTime.Now.AddHours(-5);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = this.mapearDatos(country, entity);
            await this.data.Update(country);
        }
    }

}
