using AutoMapper;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.CustomValidation;
using ProTracking.Infrastructures.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.CustomValidation
{
    public class TodoValidation
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoValidation(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool CreateObjectIsValid(TodoDTO entity)
        {
            if (entity == null) return false;
            if (entity.ProjectId == 0 || entity.CreatedBy == 0) return false;
            if (_unitOfWork.ProjectRepo.GetById(entity.ProjectId) == null || _unitOfWork.CustomerRepo.GetById(entity.CreatedBy) == null) return false;
            if (entity.Assignee != 0)
            {
                if (_unitOfWork.CustomerRepo.GetById(entity.Assignee) == null) return false;
            }
            if (entity.LabelId != 0)
            {
                if (_unitOfWork.LabelRepo.GetById(entity.LabelId) == null) return false;
            }
            return true;
        }

        public bool UpdateObjectIsValid(TodoDTO entity)
        {
            if (entity == null) return false;
            if (entity.ProjectId == 0 || entity.CreatedBy == 0) return false;
            if (_unitOfWork.ProjectRepo.GetById(entity.ProjectId) == null || _unitOfWork.CustomerRepo.GetById(entity.CreatedBy) == null) return false;
            if (entity.Assignee != 0)
            {
                if (_unitOfWork.CustomerRepo.GetById(entity.Assignee) == null) return false;
            }
            if (entity.LabelId != 0)
            {
                if (_unitOfWork.LabelRepo.GetById(entity.LabelId) == null) return false;
            }
            return true;
        }
    }
}
