using AjoOWithEF.Data;
using AjoOWithEF.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Repository
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Member> _members;
        private IGenericRepository<Account> _accounts;
        private IGenericRepository<Loan> _loans;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Member> Members => _members ??= new GenericRepository<Member>(_context);

        public IGenericRepository<Account> Accounts => _accounts ??= new GenericRepository<Account>(_context);

        public IGenericRepository<Loan> Loans => _loans ??= new GenericRepository<Loan>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
