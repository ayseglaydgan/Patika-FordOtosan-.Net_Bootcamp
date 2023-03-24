using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NiceAPI.DataLayer;
using FluentValidation.Results;
using FluentValidation;

namespace NiceAPI.WebApp.Controllers
{
    [Route("patika/hw01/NiceAPI/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IValidator<Person> validator;
        public PersonController(IUnitOfWork unitOfWork, IValidator<Person> validator)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }

        [HttpGet]
        public List<Person> GetAll()
        {
            List<Person> person = unitOfWork.PersonRepository.GetAll();
            return person;

        }

        [HttpGet("{id}")]
        public Person GetById(int id)
        {
            Person person = unitOfWork.PersonRepository.GetById(id);
            return person;
        }

        [HttpGet("GetFilterByName/{name}")]
        
        public IEnumerable<Person> GetWithWhere(string name)
        {
            IEnumerable<Person> persons = unitOfWork.PersonRepository.Where(e => e.FirstName == name);
            return persons;
        }

       
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Person person = unitOfWork.PersonRepository.GetById(id);
            try
            {
                // Check if the ID is null
                if (person ==  null)
                {
                    return "ID cannot be null";
                }

                // Do some logic to delete the product from the database
                unitOfWork.PersonRepository.Remove(id);

                // Return a success response
                return "Product deleted successfully";
            }
            catch (Exception ex)
            {
                return "An error occurred while deleting the product";
            }
        }

        [HttpPost]
        public string Post(Person person)
        {
            ValidationResult result = validator.Validate(person);
            if (!result.IsValid)
            {
                return result.ToString();
            }

            unitOfWork.PersonRepository.Insert(person);
            return "Person Added";
        }


        [HttpPut]
        public void Put(Person person)
        {
            unitOfWork.PersonRepository.Update(person);
        }

        [HttpGet("GetFilterByFullName")]
        
        public IEnumerable<Person> GetPeopleByName([FromQuery] string name, string lastname)
        {
            IEnumerable<Person> persons = unitOfWork.PersonRepository.Where(p => p.FirstName.Contains(name) && p.LastName.Contains(lastname)).ToList();
            return persons;
        }
    }
}
