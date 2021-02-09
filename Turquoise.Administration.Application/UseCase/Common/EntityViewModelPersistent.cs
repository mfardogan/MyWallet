namespace Turquoise.Administration.Application.UseCase
{
    public abstract class EntityViewModelPersistent<TPk, TEntity> : EntityViewModel<TPk> where TEntity : class
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="viewModel"></param>
        public static implicit operator TEntity(EntityViewModelPersistent<TPk, TEntity> viewModel) => viewModel.Map<TEntity>();
    }
}
