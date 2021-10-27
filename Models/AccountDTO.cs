using AjoOWithEF.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Models
{
    public class CreateAccountDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Contribution { get; set; }
        public double LoanRepayment { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public int MemberId { get; set; }
        
    }

    public class AccountDTO : CreateAccountDTO
    {
        public int Id { get; set; }
        public MemberDTO Member { get; set; }
    }
}
