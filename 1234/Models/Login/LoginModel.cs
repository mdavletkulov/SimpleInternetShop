﻿using System;
using System.ComponentModel.DataAnnotations;

namespace _1234.Models.Login
{
    public class LoginModel
    {
            [Required(ErrorMessage = "Не указан Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Не указан пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    }
}
