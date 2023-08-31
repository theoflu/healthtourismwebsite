using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using FluentValidation;
using website.Models;
namespace website.ValidationRules
{
    public class ChangePassWordAdmn : AbstractValidator<UserUpdateModel>
    {
        public ChangePassWordAdmn()
        {

            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*_-]).{8,}$");
            RuleFor(x => x.sifre).NotEmpty().WithMessage("Şifre alanı boş geçilemez!").Length(8, 20).WithMessage("Şifre alanı 8 ile 20 karakter arasında olmalıdır!").Matches(regex).WithMessage("Şifre En az bir büyük harf ,sayı ve özel karakter içermeldir");


        }

    }
}
