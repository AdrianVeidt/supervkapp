
using System.Collections.Generic;

namespace Repositories
{
	public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
	{
		void Save(TEntity entity);
		void Save(IEnumerable<TEntity> items);
		void SaveOrUpdate(TEntity entity);
		void SaveOrUpdate(IEnumerable<TEntity> items);
		void Update(TEntity entity);
		void Update(IEnumerable<TEntity> items);
		void Delete(TEntity entity);
		void Delete(IEnumerable<TEntity> items);
	}
}
