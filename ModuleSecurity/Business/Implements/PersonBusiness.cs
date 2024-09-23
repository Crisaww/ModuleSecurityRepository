using Business.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class PersonBusiness : IPersonBusiness
    {

        protected readonly IPersonData data;

        public PersonBusiness(IPersonData data)
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

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<PersonDto> persons = await this.data.GetAll();
            //var personDtos = persons.Select(person => new PersonDto
            //{
            //    Id = person.Id,
            //    First_name = person.First_name,
            //    Last_name = person.Last_name,
            //    Phone = person.Phone,
            //    Email = person.Email,
            //    Adress = person.Adress,
            //    Type_document = person.Type_document,
            //    Document = person.Document,
            //    State = person.State
            //});

            return persons;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {

            return await this.data.GetAllSelect();
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await this.data.GetById(id);
            PersonDto PersonDto = new PersonDto();

            PersonDto.Id = person.Id;
            PersonDto.First_name = person.First_name;
            PersonDto.Last_name = person.Last_name;
            PersonDto.Phone = person.Phone;
            PersonDto.Email = person.Email;
            PersonDto.Adress = person.Adress;
            PersonDto.Type_document = person.Type_document;
            PersonDto.Document = person.Document;
            PersonDto.State = person.State;
            return PersonDto;
        }



        public Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.First_name = entity.First_name;
            person.Last_name = entity.Last_name;
            person.Phone = entity.Phone;
            person.Email = entity.Email;
            person.Adress = entity.Adress;
            person.Type_document = entity.Type_document;
            person.Document = entity.Document;
            person.State = entity.State;
            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            person = this.mapearDatos(person, entity);
            return await this.data.Save(person);
        }

        public async Task Update(PersonDto entity)
        {
            Person person = await this.data.GetById(entity.Id);
            person.UpdateAt = DateTime.Now.AddHours(-5);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.mapearDatos(person, entity);
            await this.data.Update(person);
        }
    }
}
