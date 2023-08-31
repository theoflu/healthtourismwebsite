using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using FluentValidation;
using website.Models.sınıflar;
namespace website.ValidationRules
{
    public class DsignUpValidator : AbstractValidator<signup>
    {
        public DsignUpValidator()
        {


            RuleFor(x => x.name).NotEmpty().WithMessage("Ad alanı boş geçilemez!").Length(1, 20).WithMessage("Ad alanı 1 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.sname).NotEmpty().WithMessage("Soyadı alanı boş geçilemez!").Length(1, 20).WithMessage("Soyadı alanı 1 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.email).EmailAddress().NotEmpty().WithMessage("E-Posta alanı boş geçilemez!").EmailAddress().WithMessage("Geçerli bir e-posta değeri giriniz!").When(i => !string.IsNullOrEmpty(i.email));
            RuleFor(x => x.psprtno).NotEmpty().WithMessage("Pasaport No alanı boş geçilemez!").Length(11,20).WithMessage("Pasaport Numarası en az 11 karakter  olmalıdır!");
            RuleFor(x => x.telno).NotEmpty().WithMessage("Telefon No. alanı boş geçilmez!").MinimumLength(10).WithMessage("Telefon No. 10 haneden az olamaz!").MaximumLength(11).WithMessage("Telefon No. 10 haneden az olamaz!");
            RuleFor(x => x.sclno).NotEmpty().WithMessage("Sicil No alanı boş geçilemez!").Length(0,20).WithMessage("Sicil No en az 11 karakter  olmalıdır!");
            RuleFor(x => x.email).NotEmpty().WithMessage("E-posta boş olamaz!");
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*_-]).{8,}$");
            RuleFor(x => x.paswrd).NotEmpty().WithMessage("Şifre alanı boş geçilemez!").Length(6, 20).WithMessage("Şifre alanı 8 ile 20 karakter arasında olmalıdır!").Matches(regex).WithMessage("Şifre En az bir büyük harf ,sayı ve özel karakter içermeldir");


        }

    }
}
