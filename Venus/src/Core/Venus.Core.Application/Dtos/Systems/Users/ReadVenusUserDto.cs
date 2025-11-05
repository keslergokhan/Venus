using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Base;

namespace Venus.Core.Application.Dtos.Systems.Users
{
    public class ReadVenusUserDto : ReadVenusDtoBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JwtToken { get; set; }    
    }
}
