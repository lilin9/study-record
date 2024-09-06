using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper {
    public class DomainToViewModelMappingProfile: Profile {

        public DomainToViewModelMappingProfile() {
            CreateMap<Student, StudentViewModel>()
                .ForMember(s => s.County, o => o.MapFrom(s => s.Address.County))
                .ForMember(s => s.Province, o => o.MapFrom(s => s.Address.Province))
                .ForMember(s => s.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(s => s.Street, o => o.MapFrom(s => s.Address.Street));
        }
    }
}
