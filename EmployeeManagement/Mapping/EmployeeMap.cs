using AutoMapper;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Mapping
{
    public class EmployeeMap: Profile
    {
        public EmployeeMap() {
            CreateMap<Employee,EmployeeDTO>().ReverseMap().ForMember(dest => dest.Dept,
                s => s.MapFrom(x => x.DeptName));
        }
    }
}
