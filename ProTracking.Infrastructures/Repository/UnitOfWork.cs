
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
        private ApplicationDbContext _dbContext;
        

        public UnitOfWork(ApplicationDbContext db)
        {
            this._dbContext = db;
            AccountType = new AccountTypeRepo(db);
            ChildTask = new ChildTaskRepo(db);
            Project = new ProjectRepo(db);
            Comment = new CommentRepo(db);
            Customer = new CustomerRepo(db);
            Label = new LabelRepo(db);
            Payment = new PaymentRepo(db);
            ProjectParticipant = new ProjectParticipantRepo(db);
            Todo = new TodoRepo(db);
            TransactionHistory = new TransactionHistoryRepo(db);
        }

        public IAccountTypeRepo AccountType { get; private set; }

        public IChildTaskRepo ChildTask { get; private set; }

        public IProjectRepo Project { get; private set; }
        public ICommentRepo Comment { get; private set; }

        public ICustomerRepo Customer { get; private set; }

        public ILabelRepo Label { get; private set; }

        public IPaymentRepo Payment { get; private set; }

        public IProjectParticipantRepo ProjectParticipant { get; private set; }

        public ITodoRepo Todo { get; private set; }

        public ITransactionHistoryRepo TransactionHistory { get; private set; }


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
