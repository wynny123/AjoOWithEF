using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Data
{
    public class Member
    {   public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }

        public virtual IList<Account> Accounts { get; set; }
        public virtual IList<Loan> Loans { get; set; }

    }
}
