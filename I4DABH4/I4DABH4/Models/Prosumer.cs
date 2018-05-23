using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace I4DABH4.Models
{
    public class Prosumer
    {
        [Key]
        public long ProsumerId { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public int NetValue { get; set; }
    }
}
