using NiceAPI.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.DtoLayer.Dto
{
    public class AccountDto : BaseDto
    {
        
        public string? UserName { get; set; }

       
        public string? Password { get; set; }

        
        public string? Name { get; set; }

       
        public string? Email { get; set; }

        
        
        public string? Role { get; set; }


  
        public DateTime LastActivity { get; set; }
    }
}
