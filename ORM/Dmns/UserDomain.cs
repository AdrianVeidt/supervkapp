using System;
using System.Collections.Generic;


namespace Domains
{
	public class UserDomain
	{
		public virtual int Id
		{
			get;
			protected set;
		}
		public virtual string FirstName
		{
			get;
			set;
		}
		public virtual string LastName
		{
			get;
			set;
		}
		public virtual string Avatar
		{
			get;
			set;
		}
		public virtual bool Male
		{
			get;
			set;
		}
		public virtual int Age
		{
			get;
			set;
		}
		public virtual IList<PostDomain> Posts
		{
			get;
			protected set;
		}
		public virtual IList<LoginDomain> LoginUsers
		{
			get;
			protected internal set;
		}

		public UserDomain()
		{
			Posts = new List<PostDomain>();
			LoginUsers = new List<LoginDomain>();
		}

		public virtual void AddPost(PostDomain post)
		{
			post.Owner = this;
			Posts.Add(post);
		}
		public virtual void AddPosts(IEnumerable<PostDomain> posts)
		{
			foreach (var post in posts)
			{
				AddPost(post);
			}
		}
	}
}
