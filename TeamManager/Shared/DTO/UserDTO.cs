using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            FirstName = user.FirstName;
            LastName = user.LastName;
            
        }
        public UserDTO()
        {
            // Initialize collections to avoid null reference exceptions
            VacationRequests = new List<VacationRequest>();
            VacationBalances = new List<VacationBalance>();
        }

        public UserDTO(int id, string name)
        {
            Id = id;
            Email = name;
        }
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UserRole Role { get; set; }
        public Address Adress { get; set; }
        public int? DepartmentId { get; set; } // Foreign key
        public Department Department { get; set; } // User belongs to a department
        public ICollection<VacationRequest> VacationRequests { get; set; }
        public ICollection<VacationBalance> VacationBalances { get; set; }
    }
}
