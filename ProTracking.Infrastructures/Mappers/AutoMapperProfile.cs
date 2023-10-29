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
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => _unitOfWork.ProjectRepo.GetById(src.ProjectId)))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => _unitOfWork.CustomerRepo.GetById(src.CustomerId)))
                .ReverseMap();

            CreateMap<ChildTaskDTO, ChildTask>()
                .ReverseMap();

            CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.Todo, opt => opt.MapFrom(src => _unitOfWork.CommentRepo.GetAllByTodoId(src.Id)))
                .ReverseMap();

            CreateMap<TransactionHistoryDTO, TransactionHistory>()
                 .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => _unitOfWork.CustomerRepo.GetById(src.CustomerId)))
                 .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => _unitOfWork.AccountTypeRepo.GetByIdAsync(src.AccountTypeId)))
                 .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => _unitOfWork.PaymentRepo.GetByIdAsync(src.PaymentId)))
                 .ReverseMap();

            CreateMap<Customer, CustomerToken>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => _unitOfWork.CustomerRepo.GetById(src.Id).Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => _unitOfWork.CustomerRepo.GetById(src.Id).Username))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => _unitOfWork.CustomerRepo.GetById(src.Id).Role))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => _unitOfWork.AccountTypeRepo.GetById(src.AccountTypeId).Title))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => _unitOfWork.TransactionHistoryRepo.GetByCustomerIdAndActive(src.Id, true).StartDate))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => _unitOfWork.TransactionHistoryRepo.GetByCustomerIdAndActive(src.Id, true).EndDate));
        }
    }
}
