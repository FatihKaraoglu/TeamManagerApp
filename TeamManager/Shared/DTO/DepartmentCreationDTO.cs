using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Shared.DTO
{
    public class DepartmentCreationDTO
    {
        public string Name { get; set; }
        public List<User> Employees { get; set; }
        public List<User> Managerss { get; set; }
    }
}
