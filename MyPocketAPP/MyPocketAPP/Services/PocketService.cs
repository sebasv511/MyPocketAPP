using MyPocketAPP.Data.API;
using MyPocketAPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPocketAPP.Services
{
    public class PocketService : IPocketService
    {
        private readonly IPocketApi _pocketApi;
        public PocketService(IPocketApi pocketApi)
        {
            _pocketApi = pocketApi;
        }
        public async Task<List<PocketDetail>> GetPockets()
        {
            var pockets = new List<PocketDetail>();
            try
            {
                var response = await _pocketApi.GetPockets();
                pockets = response.ToList();
                return pockets;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return pockets;
        }
    }
}
