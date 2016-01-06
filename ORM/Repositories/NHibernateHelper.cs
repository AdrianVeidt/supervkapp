using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace ORM
{
	public class NHibernateHelper
	{
		private readonly string _connectionString;
		private ISessionFactory _sessionFactory;

		public ISessionFactory SessionFactory
		{
			get
			{
				return _sessionFactory ?? (_sessionFactory = CreateSessionFactory());
			}
		}

		public NHibernateHelper(string connectionString)
		{
			_connectionString = connectionString;
		}

		private ISessionFactory CreateSessionFactory()
		{
			return Fluently.Configure()
				.Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
				.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
				.BuildSessionFactory();
		}
	}
}
