using NiceAPI.BaseClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.DtoLayer
{
    public class UpdatePasswordRequest
    {
        [Required]
        
        public string OldPassword { get; set; }

        [Required]
        [Password]
        public string NewPassword { get; set; }
    }
}
