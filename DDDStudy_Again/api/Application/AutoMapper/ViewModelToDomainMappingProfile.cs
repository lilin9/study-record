using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper {
    public class ViewModelToDomainMappingProfile: Profile {
        public ViewModelToDomainMappingProfile() {
            CreateMap<StudentViewModel, Student>()
                .ForMember(s => s.Address.County, o => o.MapFrom(s => s.County))
                .ForMember(s => s.Address.Province, o => o.MapFrom(s => s.Province))
                .ForMember(s => s.Address.City, o => o.MapFrom(s => s.City))
                .ForMember(s => s.Address.Street, o => o.MapFrom(s => s.Street));
        }
    }
}
