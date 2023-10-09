using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Auth
{
    public class UserLoginDto
    {
        public String UserName { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
    }
}