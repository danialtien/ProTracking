﻿using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class CustomerToken
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string AccountType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}