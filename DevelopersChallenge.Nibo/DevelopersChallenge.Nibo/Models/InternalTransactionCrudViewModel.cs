using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Models
{
    public class InternalTransactionCrudViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O valor é obrigatório.")]
        public decimal Value { get; set; }
        [MaxLength(1000)]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Description { get; set; }
    }
}
