
using AutoMapper;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public readonly IAccountTypeRepo _accountTypeRepo;

        public readonly IChildTaskRepo _childTaskRepo ;

        public readonly ICommentRepo _commentRepo ;

        public readonly ICustomerRepo _customerRepo ;

        public readonly ILabelRepo _labelRepo ;

        public readonly IPaymentRepo _paymentRepo ;

        public readonly IProjectParticipantRepo _projectParticipantRepo ;

        public readonly IProjectRepo _projectRepo ;

        public readonly ITodoRepo _todoRepo ;

        public readonly ITransactionHistoryRepo _transactionHistoryRepo ;

        public IAccountTypeRepo AccountTypeRepo => _accountTypeRepo;

        public IChildTaskRepo ChildTaskRepo => _childTaskRepo;

        public ICommentRepo CommentRepo => _commentRepo;

        public ICustomerRepo CustomerRepo => _customerRepo;

        public ILabelRepo LabelRepo => _labelRepo;

        public IPaymentRepo PaymentRepo => _paymentRepo;

        public IProjectParticipantRepo ProjectParticipantRepo => _projectParticipantRepo;

        public IProjectRepo ProjectRepo => _projectRepo;

        public ITodoRepo TodoRepo => _todoRepo;

        public ITransactionHistoryRepo TransactionHistoryRepo => _transactionHistoryRepo;

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            this._dbContext = db;
            _accountTypeRepo = new AccountTypeRepo(db);
            _childTaskRepo = new ChildTaskRepo(db);
            _projectRepo = new ProjectRepo(db);
            _commentRepo = new CommentRepo(db);
            _customerRepo = new CustomerRepo(db);
            _labelRepo = new LabelRepo(db);
            _paymentRepo = new PaymentRepo(db);
            _projectParticipantRepo = new ProjectParticipantRepo(db);
            _todoRepo = new TodoRepo(db, mapper);
            _transactionHistoryRepo = new TransactionHistoryRepo(db);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

       
    }
}
