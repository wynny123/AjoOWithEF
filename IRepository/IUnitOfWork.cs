using AjoOWithEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.IRepository
{
    public interface IUnitOfWork : IDisposable
    {   IGenericRepository<Member> Members { get; }
        IGenericRepository<Account> Accounts { get; }
        IGenericRepository<Loan> Loans { get; }
        Task Save();
    }
}
