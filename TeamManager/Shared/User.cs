using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<UserRole> UserRoles { get; set; }

        public int DepartmentId { get; set; } // Foreign key
        public Department Department { get; set; } // User belongs to a department

        public ICollection<VacationRequest> VacationRequests { get; set; }
        public ICollection<VacationBalance> VacationBalances { get; set; }
    }
}
