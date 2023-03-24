using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NiceAPI.DataLayer;

namespace NiceAPI.WebApp.Controllers
{
    [Route("patika/hw01/NiceAPI/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public List<Account> GetAll()
        {
            List<Account> accounts = unitOfWork.AccountRepository.GetAll();
            return accounts;
        }

        
        [HttpGet("{id}")]
        public Account GetById(int id)
        {
            Account account = unitOfWork.AccountRepository.GetById(id);
            return account;
        }

        /*[HttpGet]
        public IEnumerable<Account> GetWithWhere(int id)
        {
            IEnumerable<Account> accounts = unitOfWork.AccountRepository.Where(e => e.Id == id);
            return accounts;
        }*/

        [HttpDelete("{id}")]
        public OkResult Delete(int id)
        {
            unitOfWork.AccountRepository.Remove(id);
            return Ok();
        }

        [HttpPost]
        public void Post(Account account)
        {
            unitOfWork.AccountRepository.Insert(account);
        }
         

        [HttpPut]
        public void Put(Account account)
        {
            unitOfWork.AccountRepository.Update(account);
        }

    }
}
