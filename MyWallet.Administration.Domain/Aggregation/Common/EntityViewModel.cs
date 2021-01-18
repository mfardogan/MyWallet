namespace MyWallet.Administration.Domain.Aggregation.Common
{
    public abstract class EntityViewModel<TPk> : ViewModel
    {
        /// <summary>
        /// Primary key column
        /// </summary>
        public virtual TPk Id { get; set; }
    }
}
