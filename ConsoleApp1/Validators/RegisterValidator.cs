using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagementApp.Models;
using UsersManagementApp.Services;

namespace UsersManagementApp.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterOptions>
    {
        public RegisterValidator(IUserService userService) 
        {
            RuleFor(_ => _.Username)
                .MustAsync(userService.IsUsernameUnique)
                .WithMessage("Not unique");   
        }
    }
}
