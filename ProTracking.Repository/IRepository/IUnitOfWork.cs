using ProTracking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAccountTypeRepo AccountType { get; }
        IChildTaskRepo ChildTask { get; }
        IProjectRepo Comment { get; }
        ICustomerRepo Customer { get; }
        ILabelRepo Label { get; }
        IPaymentRepo Payment { get; }
        IProjectParticipantRepo ProjectParticipant { get; }
        IProjectRepo Project { get; }
        ITodoRepo Todo { get; }
        ITransactionHistoryRepo TransactionHistory { get; }

        void Save();
    }
}
