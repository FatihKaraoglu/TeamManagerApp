using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Shared.ViewClass
{
    public class DepartmentSection
    {
        public DepartmentSection(string name, string identifier, int departmentId)
        {
            Name = name;
            Identifier = identifier;
            DepartmentId = departmentId;
        }

        public DepartmentSection(string name, bool newDepartmentOpen, string identifier, string newDeparmtentName)
        {
            Name = name;
            NewDepartmentOpen = newDepartmentOpen;
            Identifier = identifier;
            NewDeparmtentName = newDeparmtentName;
        }

        public string Name { get; init; }
        public string Identifier { get; set; }
        public bool NewDepartmentOpen { get; set; }
        public string NewDeparmtentName { get; set; }
        public int DepartmentId { get; set; }
    }
}
