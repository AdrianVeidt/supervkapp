using FluentNHibernate.Mapping;
using Domains;


namespace Maps
{
	public class PostMap : ClassMap<PostDomain>
	{
		public PostMap()
		{
			Table("Posts");
			Id(x => x.Id).Column("idPost").GeneratedBy.Assigned();
			References(x => x.Owner).Column("idOwner").Not.Nullable();
			Map(x => x.Date).Column("date");
			Map(x => x.Text).Column("text");
			Map(x=> x.Like).Column("likes");
			HasMany(x => x.Snapshots).KeyColumn("idPost").LazyLoad().Inverse().Cascade.SaveUpdate();
			References(x => x.SequenceSnaphot).Column("sequenceId").Not.Nullable();
			//HasManyToMany(x => x.LoginUsers).Table("loginuser_post").ParentKeyColumn("postId").ChildKeyColumn("loginId").LazyLoad().Cascade.SaveUpdate();
		}
	}
}
