using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Shared.DTO;

namespace TeamManager.Shared.ViewClass
{
    public class KanbanUserItem
    {
        public KanbanUserItem(string name, string identifier, UserDTO userDTO)
        {
            Name = name;
            Identifier = identifier;
            UserDTO = userDTO;
        }

        public string Name { get; init; }
        public string Identifier { get; set; }
        public UserDTO UserDTO { get; set; }
        

    }
}
