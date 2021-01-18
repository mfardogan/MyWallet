using MyWallet.Administration.Domain.Aggregation.Common;

namespace MyWallet.Administration.Domain.Abstraction
{
    public interface IViewModelVisitor
    {
        void Visit(ViewModel viewModel);
    }
}
