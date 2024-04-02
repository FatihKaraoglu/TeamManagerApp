﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Shared.DTO
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Id = user.Id;
            Email = user.Email;
            DateCreated = user.DateCreated;
            Role = user.Role;
            DepartmentId = user.DepartmentId;
            Department = user.Department;
            VacationRequests = user.VacationRequests;
            VacationBalances = user.VacationBalances;
        }

        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UserRole Role { get; set; }

        public int? DepartmentId { get; set; } // Foreign key
        public Department Department { get; set; } // User belongs to a department

        public ICollection<VacationRequest> VacationRequests { get; set; }
        public ICollection<VacationBalance> VacationBalances { get; set; }
    }
}
