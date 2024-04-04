using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } // User's first name
        public string LastName { get; set; } // User's last name
        public string? PhoneNumber { get; set; } // User's phone number
        public int? AddressId { get; set; } // Foreign key
        public Address Address { get; set; } // Navigation property

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UserRole Role { get; set; }

        public int? DepartmentId { get; set; } // Foreign key
        public Department Department { get; set; } // User belongs to a department

        public ICollection<VacationRequest> VacationRequests { get; set; }
        public ICollection<VacationBalance> VacationBalances { get; set; }
    }
}
