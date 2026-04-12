using AutoMapper;
using PromocodeFactory.Models;

namespace PromocodeFactory.Mappings
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeResponse>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<EmployeeCreateRequest, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Position, opt => opt.Ignore());

            CreateMap<EmployeeUpdateRequest, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Position, opt => opt.Ignore());
        }
    }
}
