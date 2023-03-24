using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazeChat.Shared.DTO
{
    public class RegisterDTO
    { 
        [Required, MaxLength(25)]
        public string Name { get; set; }

        [Required, MaxLength(35)]
        public string Username { get; set; }

        [Required, MaxLength(20), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
