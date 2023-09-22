﻿using ProTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Repository.IRepository
{
    public interface IChildTaskRepo : IRepository<ChildTask>
    {
        void update(ChildTask obj);
    }
}
