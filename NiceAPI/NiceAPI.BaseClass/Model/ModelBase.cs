using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceAPI.BaseClass
{
    public class ModelBase
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
