
using Domains;
using FluentNHibernate.Mapping;

namespace Maps
{
	class SnapshotSequenceMap : ClassMap<SequenceSnaphotDomain>
	{
		public SnapshotSequenceMap()
		{
			Table("snaphotsequence");

			Id(x => x.Id).Column("id").GeneratedBy.Increment();
			Map(x => x.Date).Column("date");
			//HasMany(x => x.Posts).KeyColumn("sequenceId").LazyLoad().Inverse().Cascade.SaveUpdate();
		}
	}
}
