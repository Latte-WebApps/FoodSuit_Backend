namespace FoodSuit_Backend.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class;
}