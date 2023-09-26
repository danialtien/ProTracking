using AutoMapper;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Customer, CustomerRegisterDTO>().ForMember(item => item.IsActive, opt => opt.MapFrom(
                item => item.Status == "Active" ? "Active" : "Inactive"));
        }
    }
}
