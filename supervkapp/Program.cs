using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using supervkapp;

namespace supervkapp
{
	class Program
	{
		static void Main(string[] args)
		{
			var vkobject = new Api();
			var posts = vkobject.GetFriendsTopPosts("https://vk.com/egorveidt/", (7 * 24 * 3600), 10);
			foreach (var post in posts)
			{
				Console.WriteLine("PostID \t {0} \t ownerID: {1} \t likes: {2}", post.Id, post.OwnerId, post.LikesInfo.Count);
			}
			Console.ReadKey();
		}
	}
}
