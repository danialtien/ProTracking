using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface IUnitOfWork
    {
        IAccountTypeRepo AccountType { get; }
        IChildTaskRepo ChildTask { get; }
        ICommentRepo Comment { get; }
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
