using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NiceAPI.DataLayer;
using FluentValidation.Results;
using FluentValidation;
using NiceAPI.ServiceLayer.Abstract;
using NiceAPI.ServiceLayer.Concrete;
using NiceAPI.BaseClass;
using NiceAPI.DtoLayer.Dto;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using NiceAPI.BaseClass.Types;

namespace NiceAPI.WebApp.Controllers
{
    [Route("patika/hw01/NiceAPI/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;
        public PersonController(IPersonService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Authorize]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public BaseResponse<List<PersonDto>> GetAll()
        {
            Log.Debug("PersonController.GetAll");
            var id = AccountService.GetIdFromToken(User);
            var response = service.Where(p => p.AccountId == id);
            return response;
        }


        [HttpGet("{id}")]
        [Authorize]
        public BaseResponse<PersonDto> GetById(int id)
        {
            Log.Debug("PersonController.GetById");
            var accountId = AccountService.GetIdFromToken(User);
            var response = service.GetById(id);
            if(response.Response.AccountId == accountId)
            {
                return response;
            }
            else
            {
                return new BaseResponse<PersonDto>("YOU CANNOT SEE THIS");
            }
        }

        [HttpPost]
        [Authorize]
        public BaseResponse<bool> Post([FromBody] PersonDto request)
        {
            Log.Debug("PersonController.Post");
            var accountId = AccountService.GetIdFromToken(User);
            var accountRole = AccountService.GetRoleFromToken(User);
            if(accountRole != Role.Admin)
            {
                request.AccountId = accountId;
            }
            
            var response = service.Insert(request);
            return response;
        }



        [HttpPut("{id}")]
        [Authorize]
        public BaseResponse<bool> Put(int id, [FromBody] PersonDto request)
        {
            Log.Debug("PersonController.Put");
            var accountId = AccountService.GetIdFromToken(User);
            var accountRole = AccountService.GetRoleFromToken(User);
            var response = service.GetById(id);
            if(response.Response.AccountId == accountId)
            {
                request.AccountId = accountId;
 
            }
            if(accountRole == Role.Admin || response.Response.AccountId == accountId)
            {
                var updatedResponse = service.Update(id, request);
                return updatedResponse;
            }
            else
            {
                return new BaseResponse<bool>("YOU CANNOT UPDATE THIS");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public BaseResponse<bool> Delete(int id)
        {
            Log.Debug("PersonController.Delete");
            
            var accountId = AccountService.GetIdFromToken(User);
            var accountRole = AccountService.GetRoleFromToken(User);
            var response = service.GetById(id);
            if (response.Response.AccountId == accountId || accountRole == Role.Admin)
            {
                var updatedResponse = service.Remove(id);
                return updatedResponse;
            }
            else
            {
                return new BaseResponse<bool>("YOU CANNOT DELETE THIS");
            }
        }

    }
}
