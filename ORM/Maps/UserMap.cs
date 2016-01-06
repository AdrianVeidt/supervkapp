using FluentNHibernate.Mapping;
using Domains;
using supervkapp;

namespace Maps
{
	public class UserMap : ClassMap<UserDomain>
	{
		public UserMap()
		{
			Table("Users");
			Id(x => x.Id).Column("idUser").GeneratedBy.Assigned();
			Map(x => x.FirstName).Column("firstname");
			Map(x => x.LastName).Column("lastname");
			Map(x => x.Avatar).Column("avatar");
			Map(x => x.Male).Column("isMale");
			Map(x => x.Age).Column("age");
			HasMany(x => x.Posts).KeyColumn("idOwner").LazyLoad().Inverse().Cascade.SaveUpdate();
		}
	}
}
