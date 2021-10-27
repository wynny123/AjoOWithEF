using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Data
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ApprovedBy { get; set; }
        public string Gurantor1 { get; set; }
        public string Gurantor2 { get; set; }
        public double LoanAmount { get; set; }
        public double LoanRate { get; set; }
        public double MonthsOfRepayment { get; set; }

        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        
    }
}
