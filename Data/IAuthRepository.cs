using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, String password);
        Task<ServiceResponse<String>> Login(string userName, String password);
        Task<bool> UserExists(String userName);
    }
}