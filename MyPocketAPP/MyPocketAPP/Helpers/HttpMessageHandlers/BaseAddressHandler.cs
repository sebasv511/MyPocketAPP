using MyPocketAPP.Services;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyPocketAPP.Helpers.HttpMessageHandlers
{
    public class BaseAddressHandler : DelegatingHandler
    {
        private readonly IAppUserSettingService _appUserSettingService;
        public BaseAddressHandler(IAppUserSettingService appUserSettingService)
        {
            _appUserSettingService = appUserSettingService;
        }


        public BaseAddressHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.RequestUri.AbsolutePath.EndsWith("Login"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _appUserSettingService.UserToken);
            }

            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }

}
