using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Shared.DTO;

namespace TeamManager.Shared
{
    public class ProfileForm
    {
        public ProfileForm()
        {
        }

        public ProfileForm(UserDTO userDTO)
        {
            Email = userDTO.Email;
            FirstName = userDTO.FirstName;
            LastName = userDTO.LastName;
            PhoneNumber = userDTO.Phone;

            if(userDTO.Adress != null)
            {
                Street = userDTO.Adress.Street;
                City = userDTO.Adress.City;
                State = userDTO.Adress.State;
                ZipCode = userDTO.Adress.ZipCode;
            }
           
        }

        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Phone]
        public string? PhoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;

    }
}
