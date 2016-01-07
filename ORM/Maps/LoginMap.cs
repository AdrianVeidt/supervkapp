
using Domains;
using FluentNHibernate.Mapping;

namespace Maps
{
	public class LoginMap : ClassMap<LoginDomain>
	{
		public LoginMap()
		{
			Table("logins");

			Id(x => x.Id).Column("id").GeneratedBy.Assigned();
			Map(x => x.FirstName).Column("firstname");
			Map(x => x.LastName).Column("lastname");
			Map(x => x.AccessToken).Column("accesstoken");
			
			HasManyToMany(x => x.Users)
				.Table("login_user")
				.ParentKeyColumn("loginId")
				.ChildKeyColumn("userId")
				.LazyLoad().Inverse().Cascade.SaveUpdate();

			HasManyToMany(x => x.Posts)
				.Table("login_post")
				.ParentKeyColumn("loginId")
				.ChildKeyColumn("postId")
				.LazyLoad().Inverse().Cascade.SaveUpdate();
		}
	}
}
