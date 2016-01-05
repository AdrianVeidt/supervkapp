﻿using System;
using System.Collections.Generic;
using supervkapp.Entities;

namespace Domains
{
	public class UserDomain
	{
		public virtual int Id { get; protected set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Avatar { get; set; }
		public virtual bool isMale { get; set; }
		public virtual int age { get; set; }
		public virtual IList<PostDomain> Posts { get; protected set; }
		public UserDomain()
		{
			Posts = new List<PostDomain>();
		}
		public virtual void AddPost(PostDomain post)
		{
			post.Owner = this;
			Posts.Add(post);
		}
		
	}
}
