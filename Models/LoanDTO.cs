using AjoOWithEF.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Models
{
   
    public class CreateLoanDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ApprovedBy { get; set; }
        [Required]
        public string Gurantor1 { get; set; }
        [Required]
        public string Gurantor2 { get; set; }
        [Required]
        public double LoanAmount { get; set; }
        [Required]
        public double LoanRate { get; set; }
        [Required]
        public double MonthsOfRepayment { get; set; }
        [Required]
        public int MemberId { get; set; }
        
    }
    public class LoanDTO : CreateLoanDTO
    {
        public int Id { get; set; }
        public MemberDTO Member { get; set; }
    }

    public class UpdateLoanDTO : CreateLoanDTO
    {
       
    }
}
