using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.KeyValue
{
    public class TypeEnum
    {
        public IEnumerable<SelectListItem> TypeList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Selecione", Value = ""},
                    new SelectListItem { Text = "Crédito", Value = "CREDIT"},
                    new SelectListItem { Text = "Débito", Value = "DEBIT"}
                };
            }
        }
    }
}
