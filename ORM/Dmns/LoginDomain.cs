using System.Collections.Generic;

namespace Domains
{
	public class LoginDomain
	{
		public virtual int Id { get; protected set; }
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string AccessToken { get; set; }

		public virtual IList<UserDomain> Users { get; protected internal set; }

		public virtual IList<PostDomain> Posts { get; protected internal set; }

		public LoginDomain()
		{
			Users = new List<UserDomain>();
			Posts = new List<PostDomain>();
		}

		public virtual void AddUser(UserDomain user)
		{
			Users.Add(user);
			user.LoginUsers.Add(this);
		}
		public virtual void AddUsers(IEnumerable<UserDomain> users)
		{
			foreach (var user in users)
			{
				this.AddUser(user);
			}
		}
		public virtual void AddPost(PostDomain post)
		{
			Posts.Add(post);
			//post.LoginUsers.Add(this);
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
