using AutoMapper;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Mappers
{
    public class AutoMapperProfile : Profile
    {
        private readonly IUnitOfWork _unitOfWork;
        public AutoMapperProfile(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            CreateMap<TodoDTO, Todo>()
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => _unitOfWork.ProjectRepo.GetById(src.ProjectId)))
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.LabelId != null ? _unitOfWork.LabelRepo.GetById(src.LabelId.Value) : null))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => _unitOfWork.CustomerRepo.GetById(src.CreatedBy)))
            .ReverseMap();

            CreateMap<ProjectDTO, Project>()
                .ForMember(dest => dest.Todo, opt => opt.MapFrom(src => _unitOfWork.TodoRepo.GetAllByProjectId(src.Id)))
                .ReverseMap();

            CreateMap<ProjectParticipantDTO, ProjectParticipant>()
                .ReverseMap();

            CreateMap<ChildTaskDTO, ChildTask>()
                .ReverseMap();
        }
    }
}
