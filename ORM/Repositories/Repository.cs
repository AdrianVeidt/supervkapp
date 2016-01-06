using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ISession _session;

		public Repository(ISession session)
		{
			_session = session;
		}


		#region IReadOnlyRepository<T>

		public T FindBy(object id)
		{
			return _session.Get<T>(id);
		}

		public IQueryable<T> GetAll()
		{
			return _session.Query<T>();
		}

		public T FindBy(Expression<Func<T, bool>> expression)
		{
			return this.FilterBy(expression).SingleOrDefault();
		}

		public IQueryable<T> FilterBy(Expression<Func<T, bool>> expression)
		{
			return this.GetAll().Where(expression);
		}

		#endregion


		#region IRepository<T>

		public void Save(T entity)
		{
			ActionInTransaction(
				() =>
				_session.Save(entity));
		}

		public void Save(IEnumerable<T> items)
		{
			ActionInTransaction(
				() =>
				{
					foreach (var item in items)
						_session.Save(item);
				});
		}

		public void SaveOrUpdate(T entity)
		{
			ActionInTransaction(
				() =>
				_session.SaveOrUpdate(entity));
		}

		public void SaveOrUpdate(IEnumerable<T> items)
		{
			ActionInTransaction(
				() =>
				{
					foreach (var item in items)
						_session.SaveOrUpdate(item);
				});
		}

		public void Update(T entity)
		{
			ActionInTransaction(
				() =>
				_session.Update(entity));
		}

		public void Update(IEnumerable<T> items)
		{
			ActionInTransaction(
				() =>
				{
					foreach (var item in items)
						_session.Update(item);
				});
		}

		public void Delete(T entity)
		{
			ActionInTransaction(
				() =>
				_session.Delete(entity));
		}

		public void Delete(IEnumerable<T> items)
		{
			ActionInTransaction(
				() =>
				{
					foreach (var item in items)
						_session.Delete(item);
				});
		}

		#endregion

		private void ActionInTransaction(Action action)
		{
			using (var transaction = _session.BeginTransaction())
			{
				action();
				transaction.Commit();
			}
		}
	}
}
