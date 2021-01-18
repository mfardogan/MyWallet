using MyWallet.Administration.Domain.Abstraction;

namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public abstract class ViewModel
    {
        /// <summary>
        /// Accept visitor
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IViewModelVisitor visitor) => visitor.Visit(this);
    }
}
