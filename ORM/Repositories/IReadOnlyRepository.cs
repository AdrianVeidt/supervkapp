
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
	public interface IReadOnlyRepository<TEntity> where TEntity : class
	{
		TEntity FindBy(object id);
		IQueryable<TEntity> GetAll();
		TEntity FindBy(Expression<Func<TEntity, bool>> expression);
		IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
	}
}
