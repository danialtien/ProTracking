using ProTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.CustomValidation
{
    public interface IValidation<T> where T : class
    {
        public bool CreateObjectIsValid(T entity);
    }
}
