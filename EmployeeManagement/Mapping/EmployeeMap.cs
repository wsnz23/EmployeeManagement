using AutoMapper;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Mapping
{
    public class EmployeeMap: Profile
    {
        public EmployeeMap() {
            CreateMap<EmployeeDTO , Employee>().ReverseMap().ForMember(dest => dest.DeptName,
                s => s.MapFrom(x => x.Dept.DepName));
        }
    }
}
