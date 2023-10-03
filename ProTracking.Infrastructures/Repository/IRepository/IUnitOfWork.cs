using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface IUnitOfWork
    {
        IAccountTypeRepo AccountTypeRepo { get; }
        IChildTaskRepo ChildTaskRepo { get; }
        ICommentRepo CommentRepo { get; }
        ICustomerRepo CustomerRepo { get; }
        ILabelRepo LabelRepo { get; }
        IPaymentRepo PaymentRepo { get; }
        IProjectParticipantRepo ProjectParticipantRepo { get; }
        IProjectRepo ProjectRepo { get; }
        ITodoRepo TodoRepo { get; }
        ITransactionHistoryRepo TransactionHistoryRepo { get; }

        public int Save();
        public Task<int> SaveChangeAsync();
    }
}
