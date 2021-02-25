﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ved_Organic.Data
{
    public class LoginInfo
    {
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required.")]
        public string Password { get; set; }
    }
}
