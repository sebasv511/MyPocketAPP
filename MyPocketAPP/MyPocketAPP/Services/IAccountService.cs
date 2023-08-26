using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPocketAPP.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string userName, string password);
    }
}
