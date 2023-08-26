using MyPocketAPP.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPocketAPP.Data.API
{
    public interface IPocketApi
    {
        [Get("/Pockets")]
        Task<List<PocketDetail>> GetPockets();
        [Get("/Years")]
        Task<List<PocketDetail>> GetPocketYears(long userId);
    }
}
