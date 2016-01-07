using System;
using NHibernate;

namespace ORM.UnitOfWork
{
	public interface IUnitOfWork :IDisposable
	{
		ISession Session { get; }
		void Commit();
		void Rollback();
	}
}
