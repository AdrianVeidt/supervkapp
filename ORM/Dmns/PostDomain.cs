using System;
using System.Collections.Generic;


namespace Domains
{
	public class PostDomain
	{
		public virtual int Id
		{
			get;
			protected set;
		}
		public virtual UserDomain Owner
		{
			get;
			protected internal set;
		}
		public virtual DateTime Date
		{
			get;
			set;
		}
		public virtual string Text 
		{ 
			get; 
			set; 
		}
		public virtual long Like
		{
			get;
			set;
		} 
		//public virtual SnaphotSequenceDomain SnaphotSequence { get; protected internal set; }
		//public virtual IList<PostSnapshotDomain> Snapshots { get; protected internal set; }

		public PostDomain()
		{
			//Snapshots = new List<PostSnapshotDomain>();
		}
		public virtual void SetOwner(UserDomain owner)
		{
			owner.AddPost(this);
		}
		/*public virtual void SetSequence(SnaphotSequenceDomain sequence)
		{
			sequence.AddPost(this);
		}
		public virtual void AddSnapshot(PostSnapshotDomain snapshot)
		{
			snapshot.SetPost(this);
			Snapshots.Add(snapshot);
		}*/

	}
}
