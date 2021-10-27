using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Models
{
   
    public class CreateMemberDTO
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Address { get; set; }
    }

    public class MemberDTO : CreateMemberDTO
    {
        public int Id { get; set; }
        public  IList<AccountDTO> Accounts { get; set; }
        public  IList<LoanDTO> Loans { get; set; }

    }

}
