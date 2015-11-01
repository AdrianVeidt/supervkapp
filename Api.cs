using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using supervkapp;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace supervkapp 
{
	public class Api 
	{
		private const string Url = "https://api.vk.com/method/{0}?{1}&v=5.37";
		public  ResolveResult ResolvePageAddress(string pageAddress) 
		{
			using (var webclient = new WebClient()) 
			{
				var Response = webclient.DownloadString(
					String.Format(
						Url,
						"utils.ResolvePageAddress",
						String.Format("page_Address={0}", pageAddress)));

				var response = JsonConvert.DeserializeObject<Reply<ResolveResult>>(Response);
				if (response != null)
					return response.Response;

				return null;
			}
		}
		public static string ParseUrl(string url) 
		{
			var regex = new Regex(@"(https?://)?(www\.)?vk\.com/(?<name>[a-z][a-z0-9\.]+)\/?");
			var matches = regex.Matches(url.ToLower());
			if (matches.Count != 0)
				return matches[0].Groups["name"].Value;

			throw new Exception("Url is not correct.");
		}
		public  User GetUser(uint id) 
		{
			using (var wc = new WebClient()) 
			{
				var Response = wc.DownloadString(
					String.Format(
						Url,
						"users.get",
						String.Format("user_ids={0}", id)));

				var response = JsonConvert.DeserializeObject<Reply<List<User>>>(Response);
				if (response != null &&
					response.Response != null &&
					response.Response.Count != 0)
					return response.Response[0];

				return null;
			}
		}
		public  List<User> GetUsers(params uint[] ids) 
		{
			using (var wc = new WebClient()) 
			{
				var Response = wc.DownloadString(
					String.Format(
						Url,
						"users.get",
						String.Format("user_ids={0}", string.Join(",", ids))));

				var response = JsonConvert.DeserializeObject<Reply<List<User>>>(Response);
				if (response != null &&
					response.Response != null)
					return response.Response;

				return new List<User>();
			}
		}
		public  List<User> GetFriends(uint id) 
		{
			using (var webclient = new WebClient()) 
			{
				var Response = webclient.DownloadString(
					String.Format(
						Url,
						"friends.get",
						String.Format("user_id={0}", id)));

				var response = JsonConvert.DeserializeObject<Reply<FriendsIdsResponse>>(Response);
				if (response != null &&
					response.Response.Count != 0) 
				{
					var users = new List<User>((int)response.Response.Count);
					users.AddRange(response.Response.FriendsIds.Select(userId => new User() 
					{
						Id = userId
					}));

					return users;
				}

				return new List<User>();
			}
		}
		public  List<Post> GetWallPosts(int id, uint count, uint offset) 
		{
			using (var webclient = new WebClient()) 
			{
				var Response = webclient.DownloadString(
					String.Format(
						Url,
						"wall.get",
						String.Format("owner_id={0}&Count={1}&offset={2}", id, count, offset)));

				var response = JsonConvert.DeserializeObject<Reply<PostsResponse>>(Response);
				if (response != null &&
					response.Response != null)
					return response.Response.Posts;

				return new List<Post>();
			}
		}
		public  List<Post> GetWallPosts(int id, uint dateMin) 
		{
			var posts = new List<Post>();
			var prevPostsCount = 0;

			const uint count = 10;
			uint offset = 0;

			do 
			{
				prevPostsCount = posts.Count;
				var newPosts = GetWallPosts(id, count, offset);
				posts.AddRange(newPosts.Where(post => post.Date >= dateMin));

				offset += count;
			} while ((posts.Count - prevPostsCount) == count);

			return posts;
		}
		public List<Post> GetFriendsTopPosts(string userUrl, uint lastPeriod, int count) 
		{
			var name = ParseUrl(userUrl);
			var resolveResult = this.ResolvePageAddress(name);

			if (resolveResult.Type != ResolveType.User) 
			{
				throw new Exception("not a User");
			}

			var user = this.GetUser(resolveResult.Id);

			var friends = this.GetFriends(user.Id);
			friends.Add(user);

			uint currentTime = this.GetServerTime();
			var someTimeAgo = currentTime - lastPeriod;

			var posts = new List<Post>();
			foreach (var friend in friends)
				posts.AddRange(this.GetWallPosts((int)friend.Id, someTimeAgo));

			posts = posts.OrderByDescending(p => p.LikesInfo.Count).Take(count).ToList();
			return posts;
		}
		public  uint GetServerTime() 
		{
			using (var webclient = new WebClient()) 
			{
				var Response = webclient.DownloadString(
					String.Format(
						Url,
						"utils.getServerTime",
						""));

				var response = JsonConvert.DeserializeObject<Reply<uint>>(Response);
				if (response != null)
					return response.Response;

				return 0;
			}
		}
	}
}
