﻿using System.ComponentModel.DataAnnotations;

namespace AspNetIdentityCore.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(nameof(Password), ErrorMessage ="Password and confirmation password did not match")]
        public string ConfirmPassword { get; set; }

    }
}
