using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControllerSystems.DeusCumpre.Application.DataTransferObjects
{
    public class UserDto
    {
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}