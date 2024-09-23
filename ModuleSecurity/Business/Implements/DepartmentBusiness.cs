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
    public class DepartmentBusiness : IDepartmentBusiness
    {
        protected readonly IDepartmentData data;

        public DepartmentBusiness(IDepartmentData data)
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

        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            IEnumerable<DepartmentDto> departments = await this.data.GetAll();
            //var departmentDtos = departments.Select(department => new DepartmentDto
            //{
            //    Id = department.Id,
            //    Name = department.Name,
            //    Population = department.Population,
            //    Capital = department.Capital
            //});

            return departments;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            Department department = await this.data.GetById(id);
            DepartmentDto departmentDto = new DepartmentDto();

            departmentDto.Id = department.Id;
            departmentDto.Name = department.Name;
            departmentDto.Population = department.Population;
            departmentDto.Capital = department.Capital;
            departmentDto.CountryId = department.CountryId;

            return departmentDto;
        }

        public Department mapearDatos(Department department, DepartmentDto entity)
        {
            department.Id = entity.Id;
            department.Name = entity.Name;
            department.Population = entity.Population;
            department.Capital = entity.Capital;
            department.CountryId = entity.CountryId;
            return department;
        }

        public async Task<Department> Save(DepartmentDto entity)
        {
            Department department = new Department
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            department = this.mapearDatos(department, entity);
            return await this.data.Save(department);
        }

        public async Task Update(DepartmentDto entity)
        {
            Department department = await this.data.GetById(entity.Id);
            department.UpdateAt = DateTime.Now.AddHours(-5);
            if (department == null)
            {
                throw new Exception("Registro no encontrado");
            }
            department = this.mapearDatos(department, entity);
            await this.data.Update(department);
        }
    }
}
