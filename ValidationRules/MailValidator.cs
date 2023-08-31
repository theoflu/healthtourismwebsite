using FluentValidation;
using FluentValidation.Results;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website.Models.sınıflar;

namespace website.ValidationRules
{
    public class MailValidator : AbstractValidator<contact_adres>
    {
        public MailValidator()
        {
            //Regex regEx = new Regex("^[a-zA-Z0]*$");

            RuleFor(x => x.iltsm.AdSoyad).NotEmpty().WithMessage("Ad alanı boş geçilemez!").Length(1, 20).WithMessage("Ad alanı 5 ile 20 karakter arasında olmalıdır!");

            RuleFor(x => x.iltsm.mail).EmailAddress().NotEmpty().WithMessage("E-Posta alanı boş geçilemez!");
            RuleFor(x => x.iltsm.mail).EmailAddress().WithMessage("Geçerli bir e-posta değeri giriniz!").When(i => !string.IsNullOrEmpty(i.iltsm.mail));



            RuleFor(c => c.iltsm.mTarih).NotEmpty().WithMessage("Lütfen Doğru bir tarih seçiniz.");
            RuleFor(x => x.iltsm.phone).NotEmpty().WithMessage("Telefon No. alanı boş geçilmez!").MinimumLength(10).WithMessage("Telefon No. 10 haneden az olamaz!").MaximumLength(11).WithMessage("Telefon No. 10 haneden az olamaz!");

            RuleFor(x => x.iltsm.mail).NotEmpty().WithMessage("E-posta boş olamaz!");





        }
    }
}