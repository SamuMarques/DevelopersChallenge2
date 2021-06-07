using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Domain
{
    public class ExternalTransaction
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }
        public int? InternalTransactionId { get; set; }
        [MaxLength(1000)]
        public string InternalTransactionDescription { get; set; }
    }
}
