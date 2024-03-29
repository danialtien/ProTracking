﻿using ProTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface ILabelRepo : IGenericRepository<Label>
    {
        Label GetById(int? id);
    }
}
