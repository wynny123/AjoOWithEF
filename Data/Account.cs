using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Data
{
    public class Account
    {  
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Contribution { get; set; }
        public double LoanRepayment { get; set; }
        public double Balance { get; set; }

        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        
    }
}
