using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDependencyInjectionWithIdentity.Models
{
    public class Prospect
    {
        [Key]
        public Guid Id { get; set; }

        public string MyName { get; set; }
    }
}