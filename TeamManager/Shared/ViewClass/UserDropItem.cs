using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Shared.DTO;

namespace TeamManager.Shared.ViewClass
{
    public class UserDropItem
    {
        public UserDropItem(UserDTO userDTO, string identifier)
        {
            UserDTO = userDTO;
            Identifier = identifier;
        }

        public UserDTO UserDTO { get; init; }
        public string Identifier { get; set; }
    }
}
