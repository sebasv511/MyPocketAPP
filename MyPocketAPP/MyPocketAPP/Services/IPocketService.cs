using MyPocketAPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPocketAPP.Services
{
    public interface IPocketService
    {
        Task<List<PocketDetail>> GetPockets();
    }
}
