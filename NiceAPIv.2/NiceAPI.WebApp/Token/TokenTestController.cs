using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using NiceAPI.BaseClass;
using NiceAPI.BaseClass.Types;
using NiceAPI.DtoLayer;
using NiceAPI.ServiceLayer.Abstract;
using NiceAPI.ServiceLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NiceAPI.WebApp
{
    [Route("patika/hw01/NiceAPI/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        public TokenTestController()
        {
        }


        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }

        [HttpGet("Admin")]
        [Authorize(Roles = Role.Admin)]
        public string Admin()
        {
            return "Admin";
        }

        [HttpGet("Viewer")]
        [Authorize(Roles = Role.Viewer)]
        public string Viewer()
        {
            return "Viewer";
        }

        [HttpGet("AdminViewer")]
        [Authorize(Roles = Role.Admin + "," + Role.Viewer)]

        public string AdminViewer()
        {
            return "AdminViewer";
        }

        [HttpGet("EditorQTDAEditorQTNS")]
        [Authorize(Roles =  Role.EditorQTNS + "," + Role.EditorQTDA)]

        public string EditorQTDAEditorQTNS()
        {
            return "EditorQTDAEditorQTNS";
        }


        [HttpGet("TestAccount")]
        [Authorize]
        public string TestAccount()
        {
            var claimsList = User.Claims;

            var account = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();
            var accountId = account.Value;


            var url = HttpContext.Request.Path;

            var id = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return "TestAccount";
        }
    }

}