using System;
using System.Collections.Generic;

namespace Domains
{
	public class SequenceSnaphotDomain
	{
		public virtual int Id { get; protected set; }
		public virtual DateTime Date { get; set; }

		public virtual IList<PostDomain> Posts { get; protected internal set; }

		public SequenceSnaphotDomain()
		{
			Posts = new List<PostDomain>();
		}

		public virtual void AddPost(PostDomain post)
		{
			post.SequenceSnaphot = this;
			Posts.Add(post);
		}
	}
}
