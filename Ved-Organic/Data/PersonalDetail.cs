using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ved_Organic.Data
{
    public class PersonalDetail
    {

            [Key]
            public int UserId { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            [Phone]
            public string Phone1 { get; set; }
          
            [Required]
             public string Email { get; set; }
            [Required(ErrorMessage = "password is required.")]
            [MinLength(8, ErrorMessage = "password must be atleast 8 characters")]
            public string Password { get; set; }
            [Compare(nameof(Password), ErrorMessage = "password dosent match")]
            public string ConfirmPassword { get; set; }
            [Required]
            public string Street { get; set; }
            [Required]
            public string Building { get; set; }
            [Required]
            public string Area1 { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string Country { get; set; }
            [Required]
            public string PBNo { get; set; }
            [Required]
            [Phone]
            public string Phone2 { get; set; }
            [Required]
            public string AddressType { get; set; }
      

    }
    }
