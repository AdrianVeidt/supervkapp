using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using supervkapp;

namespace supervkapp {
	class Program {
		static void Main(string[] args) {
			var vkobject = new Api();
			var posts = vkobject.GetFriendsTopPosts("https://vk.com/egorveidt/", (1 * 24 * 3600), 5);

			foreach (var post in posts) {
				Console.WriteLine("Id: {0:D9}; likes: {1}", post.Id, post.LikesInfo.Count);
			}

			Console.ReadKey();
		}
	}
}
