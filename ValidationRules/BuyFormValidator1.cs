﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using FluentValidation;
using website.Models.sınıflar;
namespace website.ValidationRules
{
    public class BuyFormValidator1 : AbstractValidator<ForBuy>
    {
        public BuyFormValidator1()
        {
            //Regex regEx = new Regex("^[a-zA-Z0]*$");
            RuleFor(x => x.db.Ad).NotEmpty().WithMessage("Ad alanı boş geçilemez!").Length(1, 20).WithMessage("Ad alanı 1 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.db.BabaAdi).NotEmpty().WithMessage("Baba Adı alanı boş geçilemez!").Length(1, 20).WithMessage("Baba Adı alanı 1 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.db.Soyad).NotEmpty().WithMessage("Soyadı alanı boş geçilemez!").Length(1, 20).WithMessage("Soyadı alanı 1 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.db.Eposta).EmailAddress().NotEmpty().WithMessage("E-Posta alanı boş geçilemez!").EmailAddress().WithMessage("Geçerli bir e-posta değeri giriniz!").When(i => !string.IsNullOrEmpty(i.db.Eposta));
            //RuleFor(x => x.db.Cinsiyet).NotEmpty().WithMessage("Cinsiyet alanı boş geçilemez!");
            RuleFor(x => x.db.Dyeri).NotEmpty().WithMessage("Doğum yeri alanı boş geçilemez!");
            RuleFor(x => x.db.PasaportNo).NotEmpty().WithMessage("Pasaport No alanı boş geçilemez!").MaximumLength(20).WithMessage("Pasaport Numarası en fazla 20 karakter arasında olmalıdır!");
            RuleFor(c => c.db.Gtarihi).NotEmpty().WithMessage("Lütfen Doğru bir tarih seçiniz.");
            RuleFor(c => c.db.Ttarihi).NotEmpty().WithMessage("Lütfen Doğru bir tarih seçiniz.");
            RuleFor(c => c.db.Dontarihi).NotEmpty().WithMessage("Lütfen Doğru bir tarih seçiniz.");
            RuleFor(c => c.db.Dtarihi).NotEmpty().WithMessage("Lütfen Doğru bir tarih seçiniz.");
            RuleFor(x => x.db.Tlfn).NotEmpty().NotNull().WithMessage("Telefon No. alanı boş geçilmez!").MinimumLength(10).WithMessage("Telefon No. 10 haneden az olamaz!").MaximumLength(11).WithMessage("Telefon No. 10 haneden az olamaz!");
            //RuleFor(x => x.db.Tlfn_kdu).NotEmpty().WithMessage("Ülke kodu alanı boş geçilemez!");
            //RuleFor(x => x.db.Uyruk).NotEmpty().WithMessage("Uyruk alanı boş geçilemez!");
            RuleFor(x => x.db.sigorta_ettiren_tuzel.VergiNo).NotEmpty().WithMessage("Vergi Numarası alanı boş geçilemez!");
            RuleFor(x => x.db.sigorta_ettiren_tuzel.VEposta).EmailAddress().WithMessage("Geçerli bir e-posta değeri giriniz!").When(i => !string.IsNullOrEmpty(i.db.Eposta));
            RuleFor(x => x.db.sigorta_ettiren_tuzel.VTlfn).NotEmpty().NotNull().WithMessage("Telefon No. alanı boş geçilmez!").MinimumLength(10).WithMessage("Telefon No. 10 haneden az olamaz!").MaximumLength(11).WithMessage("Telefon No. 10 haneden az olamaz!");
            RuleFor(x => x.db.Eposta).NotEmpty().WithMessage("E-posta boş olamaz!");


        }
    }
}