using NiceAPI.BaseClass;
using System;
using System.ComponentModel.DataAnnotations;


namespace NiceAPI.DtoLayer.Dto
{
    public class PersonDto : BaseDto
    {

        public int AccountId { get; set; }
        public string? StaffId { get; set; }

        public string? FirstName { get; set; }

       
        public string? LastName { get; set; }

        
        public string? Email { get; set; }

        public string? Description { get; set; }
        public string? Phone { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        
        public string? FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }

}
