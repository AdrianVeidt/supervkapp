using System.Reflection;

using Castle.Core.Internal;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;

namespace DatabaseAccess
{
	public class NHibernateHelper
	{
		private readonly string _connectionString;
		private readonly Assembly[] _assemblies;
		private ISessionFactory _sessionFactory;

		public ISessionFactory SessionFactory
		{
			get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
		}

		private ISessionFactory CreateSessionFactory()
		{
			return Fluently.Configure()
			               .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
			               .Mappings(
				               m => _assemblies.ForEach(a => m.FluentMappings.AddFromAssembly(a)))
			               .BuildSessionFactory();
		}

		public NHibernateHelper(string connectionString, params Assembly[] assemblies)
		{
			_connectionString = connectionString;
			_assemblies = assemblies;
		}

	}
}
