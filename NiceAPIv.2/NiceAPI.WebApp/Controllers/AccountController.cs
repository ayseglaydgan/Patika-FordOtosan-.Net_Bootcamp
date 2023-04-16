using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceAPI.BaseClass;
using NiceAPI.BaseClass.Types;
using NiceAPI.DtoLayer.Dto;
using NiceAPI.ServiceLayer.Abstract;
using Serilog;
using System.Collections.Generic;
using NiceAPI.ServiceLayer.Concrete;

namespace NiceAPI.WebApp.Controllers
{
    [Route("patika/hw01/NiceAPI/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Authorize]
        public BaseResponse<List<AccountDto>> GetAll()
        {
            Log.Debug("AccountController.GetAll");
            var response = service.GetAll();
            return response;
        }

        [HttpGet("GetUserDetail")]
        [Authorize]
        public BaseResponse<AccountDto> GetUserDetail()
        {
            Log.Debug("AccountController.GetByUsername");
            var id = AccountService.GetIdFromToken(User);
            var response = service.GetById(id);
            return response;
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public BaseResponse<bool> Post([FromBody] AccountDto request)
        {
            Log.Debug("AccountController.Post");
            var response = service.Insert(request);
            return response;
        }

        //If a user login as ADMIN, it can update any info
        [HttpPut("{id}")]
        [Authorize(Roles = Role.Admin)]
        public BaseResponse<bool> Put(int id, [FromBody] AccountDto request)
        {
            Log.Debug("AccountController.Put");
            var response = service.Update(id, request);
            return response;
        }

        [HttpPut]
        [Authorize(Roles = Role.RolesExceptAdmin)]
        public BaseResponse<bool> Put([FromBody] AccountDto request)
        {
            Log.Debug("AccountController.Put");
            var id = AccountService.GetIdFromToken(User);
            var response = service.Update(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public BaseResponse<bool> Delete(int id)
        {
            Log.Debug("AccountController.Delete");
            var response = service.Remove(id);
            return response;
        }

        [HttpDelete]
        [Authorize(Roles = Role.RolesExceptAdmin)]
        public BaseResponse<bool> Delete()
        {
            Log.Debug("AccountController.Delete");
            var id = AccountService.GetIdFromToken(User);
            var response = service.Remove(id);
            return response;
        }

    }
}
