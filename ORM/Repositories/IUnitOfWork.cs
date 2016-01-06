using System;
using NHibernate;

namespace UnitOfWork
{
	public interface IUnitOfWork :IDisposable
	{
		ISession Session { get; }
		void Commit();
		void Rollback();
	}
}
