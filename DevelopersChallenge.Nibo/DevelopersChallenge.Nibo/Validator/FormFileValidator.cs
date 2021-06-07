//using DevelopersChallenge.Nibo.Domain;
//using FluentValidation;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace DevelopersChallenge.Nibo.Validator
//{
//    public class FormFileValidator : AbstractValidator<IFormFile>
//    {
//        public FormFileValidator()
//        {
//            RuleFor(customer => Path.GetExtension(customer.FileName).ToLower()).Equal(".ofx");
//        }
//    }
//}
