
using Domains;
using FluentNHibernate.Mapping;

namespace Maps
{
	public class SnapshotPostMap : ClassMap<PostSnapshotDomain>
	{
		public SnapshotPostMap()
		{
			Table("snapshotpost");

			Id(x => x.Id).Column("id").GeneratedBy.Increment();
			//References(x => x.Post).Column("postsid").Not.Nullable();
			Map(x => x.Date).Column("date");
			Map(x => x.CountComments).Column("countcomments");
			Map(x => x.CountLikes).Column("countlikes");
			Map(x => x.CountReposts).Column("countreposts");
		}
	}
}
