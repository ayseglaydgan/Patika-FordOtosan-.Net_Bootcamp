using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using NiceAPI.BaseClass;
using NiceAPI.DtoLayer;
using NiceAPI.ServiceLayer.Abstract;
using NiceAPI.ServiceLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NiceAPI.WebApp
{
    [Route("patika/hw01/NiceAPI/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;
        public TokenController(ITokenManagementService tokenManagementService)
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost]
        public BaseResponse<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = tokenManagementService.GenerateToken(request);
            return response;
        }


    }
}
