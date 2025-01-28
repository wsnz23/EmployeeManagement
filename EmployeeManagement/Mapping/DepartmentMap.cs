using AutoMapper;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Mapping
{
    public class DepartmentMap : Profile
    {
        public DepartmentMap()
        {
            //Map Department to DepartmentDTO and vice versa
            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}
