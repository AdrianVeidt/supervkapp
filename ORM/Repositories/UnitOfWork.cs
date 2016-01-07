using System;
using System.Data;
//using System.Transactions;
using NHibernate;

namespace ORM.UnitOfWork
{
	[Obsolete("Use sessions with transactions")]
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ITransaction _transaction;

		public ISession Session { get; private set; }

		public UnitOfWork(ISessionFactory sessionFactory)
		{

			this.Session = sessionFactory.OpenSession();
			Session.FlushMode = FlushMode.Auto;

			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public void Commit()
		{
			if (!_transaction.IsActive)
			{
				throw new InvalidOperationException("No active transaction");
			}
			_transaction.Commit();
		}

		public void Rollback()
		{
			if (_transaction.IsActive)
			{
				_transaction.Rollback();
			}
		}

		public void Dispose()
		{
			Session.Close();
		}
	}
}
