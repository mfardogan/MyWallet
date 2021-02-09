namespace Turquoise.Administration.Application.UseCase
{
    public abstract class EntityViewModel<TPk> : ViewModel
    {
        public EntityViewModel() { }
        public EntityViewModel(TPk id) => Id = id;

        /// <summary>
        /// Primary key column
        /// </summary>
        public virtual TPk Id { get; set; }
    }
}
