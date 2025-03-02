using System.Linq.Expressions;

namespace DP.Services.Interfaces
{
    public interface IValidationServiceGeneric
    {
        Task CheckEntityExistsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string errorMessage)
            where TEntity : class;

        Task CheckEntityNotExistsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, string errorMessage)
            where TEntity : class;
    }
}
