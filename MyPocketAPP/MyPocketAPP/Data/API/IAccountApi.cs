using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyPocketAPP.Data.API
{
    public interface IAccountApi
    {
        [Get("/Account/Login")]
        Task<HttpResponseMessage> LoginAsync(string login, string password);
    }
}
