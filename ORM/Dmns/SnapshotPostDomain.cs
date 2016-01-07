
using System;

namespace Domains
{
	public class PostSnapshotDomain
	{
		public virtual int Id { get; protected set; }
		public virtual PostDomain Post { get; protected set; }
		public virtual DateTime Date { get; set; }

		public virtual uint CountComments { get; set; }
		public virtual uint CountLikes { get; set; }
		public virtual uint CountReposts { get; set; }

		protected internal virtual void SetPost(PostDomain post)
		{
			Post = post;
		}
	}
}
