namespace Turquoise.Administration.Domain.Aggregation.Common
{
    public interface ICommand<TEntity, TPk> where TEntity : Entity<TPk>
    {
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TPk id);
    }
}
